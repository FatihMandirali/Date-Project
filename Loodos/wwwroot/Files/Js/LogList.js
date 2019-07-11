var app = angular.module("LogList", []);

app.controller("logList", function ($scope, $http) {
    $http.get("http://localhost:62600/api/Date/GetLogList").then(function (response) {
        $scope.loglist = response.data;
    });
});