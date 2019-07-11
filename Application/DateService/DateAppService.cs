using Application.DateService.Request;
using Application.DateService.Response;
using Core.Repositories.DateRepository;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace Application.DateService
{
    public class DateAppService : IDateAppService
    {

        private readonly IDateRepository _dateRepository;
        public DateAppService(IDateRepository dateRepository)
        {
            _dateRepository = dateRepository;
        }

        public BaseResponse DateCreate(DateRequest dateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            StreamWriter sw = File.AppendText(@"wwwroot\Files\Log\Log.txt");
            try
            {
                sw.WriteLine("GET İsteğinde Bulunuldu. Tarih : " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));

                if (_dateRepository.List(x => x.RequestDate >= DateTime.Now.AddMinutes(-1)).Count() > 10)
                {
                    sw.WriteLine("Fazla İstek Hatası");
                    baseResponse.isOkey = false;
                    baseResponse.message = "1 Dk İçerisinde En Fazla 10 Kez İstekte Bulunabilirsiniz.";
                }
                else
                {
                    TimeSpan Sonuc = dateRequest.endDate - dateRequest.startDate;
                    if (Sonuc.Days < 0)
                    {
                        sw.WriteLine("Yanlış Aralıklı Tarih Hatası");
                        baseResponse.isOkey = false;
                        baseResponse.message = "Bitiş Tarihi Başlangıç Tarihinden Büyük Olmalıdır.";
                    }
                    else
                    {
                        int count = 0;

                        for (DateTime startDate = dateRequest.startDate; startDate <= dateRequest.endDate; startDate = startDate.AddDays(1))
                        {

                            if (startDate.DayOfWeek == DayOfWeek.Sunday && startDate.Day == 1)
                            {
                                count++;
                            }

                        }

                        Date date = new Date();
                        date.EndDate = dateRequest.endDate;
                        date.StartDate = dateRequest.startDate;
                        date.Result = count;
                        date.RequestDate = DateTime.Now;
                        _dateRepository.Insert(date);

                        baseResponse.isOkey = true;
                        baseResponse.message = "Girilen Tarihler Arasında Ayın İlk Günü " + count + " Kez Pazar Gününe Denk Gelmiştir.";

                    }
                }

            }
            catch (Exception)
            {
                sw.WriteLine("Veri Tabanı Bağlatı Hatası");
                baseResponse.isOkey = false;
                baseResponse.message = "Lütfen Veri Tabanı Bağlantınızı Kontrol Edin.";

            }


            sw.Flush();
            sw.Close();
            return baseResponse;
        }

        public List<LogResponse> LogList()
        {
            string rt = File.ReadAllText(@"wwwroot\Files\Log\Log.txt");

            string[] rows;
            rows = rt.Split('\n');

            List<LogResponse> logResponses = new List<LogResponse>();

            for (int i = rows.Length; i > 0; i--)
            {
                if (rows[i - 1] == "")
                    continue;

                logResponses.Add(new LogResponse()
                {

                    log = rows[i - 1]
                });


            }

            return logResponses;
        }
    }
}
