using Application.DateService.Request;
using Application.DateService.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DateService
{
    public interface IDateAppService
    {
        BaseResponse DateCreate(DateRequest dateRequest);
        List<LogResponse> LogList();
    }
}
