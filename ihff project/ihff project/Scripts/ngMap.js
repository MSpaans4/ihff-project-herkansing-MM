var app = angular.module('myApp', ['uiGmapgoogle-maps']);
app.controller('mapController', function ($scope, $http) {

    //this is for default map focus when load first time
    $scope.map = { center: { latitude: 52.3810724, longitude: 4.637334799999962 }, zoom: 15 }

    $scope.markers = [];
    $scope.locations = [];

    //Show / Hide marker on map
    $scope.windowOptions = {
        show: true
    };

});