(function () {
    'use strict';

    var baseUrl = 'http://localhost:56190/api/subdomain/';

    var app = angular.module('app', []);
    app.controller('subDomainController', ['$scope', '$http', subDomainController]);

    function subDomainController($scope, $http) {
        $scope.loading = false;
        $scope.subDomainMode = false;
        $scope.ipMode = true;

        $scope.listSubDomains = function () {
            $http.get(baseUrl + 'enumerate?domainname=' + $scope.newsubDomain.name)
            .success(function (data) {
                $scope.subDomains = data;
                $scope.ipAddresses = null;
                $scope.loading = false;
            }).error(function () {
                $scope.error = "An Error has occured while loading subdomains!";
                $scope.loading = false;
            });
        };

        $scope.findIpAddresses = function () {
            $scope.loading = true;
            $scope.subDomainMode = true;
            $scope.ipMode = false;
            var newitem = $scope.subDomains;
            for (var i = 0; i <= newitem.length; i += 10) {
                var forSlicing = newitem;
                var query = forSlicing.slice(i, i + 10);
                $http.post(baseUrl + 'findipaddresses', query)
                    .success(function (data) {
                        if ($scope.ipAddresses == null) {
                            $scope.ipAddresses = data;
                        } else {
                            $scope.ipAddresses = $scope.ipAddresses.concat(data);
                        }
                        $scope.loading = false;
                    })
                    .error(function (data) {
                        $scope.error = "An Error has occured while getting ipAddresses! " + data;
                        $scope.loading = false;
                    });
            }
        };
    }
})();