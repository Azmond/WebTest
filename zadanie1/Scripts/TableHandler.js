/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="typings/angularjs/angular.d.ts" />
/// <reference path="typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
var DataTable = (function () {
    function DataTable() {
    }
    return DataTable;
}());
var ViewDataTable = (function () {
    function ViewDataTable() {
    }
    return ViewDataTable;
}());
var dataTableApp = angular.module('dataApp', ['ui.bootstrap']);
dataTableApp.controller('NavigationController', function ($scope, $http) {
    $scope.loaddata = function (page, rowperpage) {
        $.post('/UpdateData', { page: page, record: rowperpage }).done(function (d) {
            $scope.bigTotalItems = d.MaxRows;
            var table = '<table class="table table-bordered table-striped">';
            table += '<thead><tr><th>#</th><th>Name</th><th>Age</th></tr></thead>';
            table += '<tbody>';
            for (var i = 0; i < d.data.length; i++) {
                var tableRow = '<tr>' +
                    '<td>' + d.data[i].Id + '</td>' +
                    '<td>' + d.data[i].Name + '</td>' +
                    '<td>' + d.data[i].Age + '</td>' +
                    '</tr>';
                table += tableRow;
            }
            table += '</tbody></table>';
            $('#content').html(table);
            $('#allrec').html('Всего записей: ' + d.MaxRows.toString());
        });
    };
    $scope.singleModel = 1;
    $scope.radioModel = '10';
    $scope.$watch('radioModel', function (news, olds) {
        $scope.pageSize = news;
        $scope.loaddata($scope.bigCurrentPage, $scope.pageSize);
    });
    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };
    $scope.pageSize = 10;
    $scope.maxSize = 5;
    $scope.bigTotalItems = 600;
    $scope.bigCurrentPage = 1;
    $scope.$watch('bigCurrentPage', function (news, olds) {
        $scope.loaddata($scope.bigCurrentPage, $scope.pageSize);
    });
});
//# sourceMappingURL=TableHandler.js.map