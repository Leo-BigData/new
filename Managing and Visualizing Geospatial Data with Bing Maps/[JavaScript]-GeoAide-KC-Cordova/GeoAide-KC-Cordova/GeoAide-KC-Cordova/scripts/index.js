//window.onresize = resize;

var map = null;
var mapHeight = 0;
var searchResultPage = 0;
var click = null;
var currInfobox = null;
var bmKey = "YOUR_BING_MAPS_KEY";
var baseUrl = "http://spatial.virtualearth.net/REST/v1/data/";

// School Districts in SDS
var vl1 = 0;
var ds1Id = "e31c831f5c4945dd81493a7efcc76df9";
var ds1Name = "KingCountySchDst";
var ds1EntityName = "SchDst";

// School Sites in SDS
var vl2 = 0;
var ds2Id = "f3526802415a4913b9d35ff2a67a88e1";
var ds2Name = "KingCountySchSite";
var ds2EntityName = "KingCountySchSite";

var tl1 = 0;
var vl3 = 0;
var ds3Id = "8d0cefb0710044f0ab719a06cb5d6b57";
var ds3Name = "KingCountyParcel";
var ds3EntityName = "KingCountyParcel";
var tl2 = 0;
var tl3 = 0;
var tl4 = 0;
var tl5 = 0;

//Heatmap Properties
var ds4Id = '4509c497f7984da5aad34974390d54c4';
var ds4Name = 'VaFacilities';
var ds4EntityName = 'Facility';
var hmIntensity = 0.5;
var hmRadius = 100000;
var hl1 = 0;
var heatmapLayer = null;
var searchResultsArray = null;

//Safe characters for decoding of GeoData
var safeCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_-";

//load the map, set a theme and define the map view
(function () {
    "use strict";

    document.addEventListener( 'deviceready', onDeviceReady.bind( this ), false );

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener( 'pause', onPause.bind( this ), false );
        document.addEventListener( 'resume', onResume.bind( this ), false );
        
        Microsoft.Maps.loadModule('Microsoft.Maps.Themes.BingTheme', {
            callback: function () {

                map = new Microsoft.Maps.Map(document.getElementById('divMap'), {
                    credentials: bmKey,
                    mapTypeId: Microsoft.Maps.MapTypeId.road,
                    center: new Microsoft.Maps.Location(47.490860, -121.835747),
                    zoom: 9,
                    theme: new Microsoft.Maps.Themes.BingTheme(),
                    showDashboard: true,
                    enableClickableLogo: false,
                    enableSearchLogo: false
                });
            }
        });

        resize();

        loadAdvancedShapeModule();
    };

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
    };
})();

//the advanced shape module is part of the Bing Maps Platform and allows us
//to handle multi-geometries and polygons with holes
function loadAdvancedShapeModule() {
    Microsoft.Maps.loadModule('Microsoft.Maps.AdvancedShapes', {
        callback: loadWKTModule
    });
}

// the WKT module reads and writes spatial data 
// dscribed as Well-Known Text
function loadWKTModule() {
    Microsoft.Maps.loadModule('WKTModule');
}

//Toggle School Districts
function toggleVL1() {
    if (vl1 == 0) {
        vl1 = 1;
        getVL1();
    }
    else {
        vl1 = 0;
        clearMap();
    }
}

function getVL1() {
    map.getCredentials(function (credentials) {
        var sdsRequest =
            baseUrl +
            ds1Id + "/" +
            ds1Name + "/" +
            ds1EntityName +
            "?SpatialFilter=bbox(47.08486,-122.5285,47.78058,-121.06428)" +
            "&$top=250&$inlinecount=allpages&$format=json&jsonp=ds1Callback" +
            "&key=" + credentials;

        var mapscript = document.createElement('script');
        mapscript.type = 'text/javascript';
        mapscript.src = sdsRequest;
        document.getElementById('divMap').appendChild(mapscript);
    });
}

function ds1Callback(result) {
    if (result &&
                result.d &&
                result.d.results &&
                result.d.results.length > 0) {

        for (var i = 0; i < result.d.results.length; i++) {
            var entity = result.d.results[i];
            var geomStyles = {
                pushpinOptions: {
                    icon: "blueCircle10.png",
                    height: 10,
                    width: 10,
                    anchor: new Microsoft.Maps.Point(5, 5)
                },
                polylineOptions: {
                    strokeColor: new Microsoft.Maps.Color(100, 255, 255, 255)
                },
                polygonOptions: {
                    fillColor: new Microsoft.Maps.Color(0, 0, 0, 0),
                    strokeColor: new Microsoft.Maps.Color(100, 255, 0, 0)
                }
            };
            var shape = WKTModule.Read(entity.Geom, geomStyles);
            map.entities.push(shape);
        }
    }
}

//Toggle School Sites
function toggleVL2() {
    if (vl2 == 0) {
        vl2 = 1;
        getVL2();
    }
    else {
        vl2 = 0;
        clearMap();
    }
}

function getVL2() {
    map.getCredentials(function (credentials) {
        var sdsRequest =
            baseUrl +
            ds2Id + "/" +
            ds2Name + "/" +
            ds2EntityName +
            "?SpatialFilter=bbox(47.08486,-122.5285,47.78058,-121.06428)" +
            "&$top=250&$inlinecount=allpages&$format=json&jsonp=ds2Callback" +
            "&key=" + credentials;

        var mapscript = document.createElement('script');
        mapscript.type = 'text/javascript';
        mapscript.src = sdsRequest;
        document.getElementById('divMap').appendChild(mapscript);
    });
}

function ds2Callback(result) {
    if (result &&
                result.d &&
                result.d.results &&
                result.d.results.length > 0) {

        for (var i = 0; i < result.d.results.length; i++) {
            createMapPin(result.d.results[i]);
        }
    }
}

//Add Pins for school sites
function createMapPin(result) {
    if (result) {
        var location = new Microsoft.Maps.Location(result.Latitude, result.Longitude);
        var pushpinOptions = { icon: "./images/blueCircle10.png", height: 10, width: 10, anchor: new Microsoft.Maps.Point(5, 5) };
        var pin = new Microsoft.Maps.Pushpin(location, pushpinOptions);
        pin.title = result.Name;
        pin.desc = result.AddressLine + "<br>" + result.PostalCode + "<br><br>School-District: " + result.SchoolDistrict;
        if (result.URL.length > 0) {
            pin.desc = pin.desc + "<br><br><a href='" + result.URL + "' target='_blank'>More Info</a><br>";
        }
        Microsoft.Maps.Events.addHandler(pin, 'click', showInfoBox);
        map.entities.push(pin);
    }
}

//add infobox when click on pin is detected
function showInfoBox(e) {
    if (e.targetType == 'pushpin') {
        if (currInfobox) {
            currInfobox.setOptions({ visible: true });
            map.entities.remove(currInfobox);
        }

        currInfobox = new Microsoft.Maps.Infobox(
            e.target.getLocation(),
            {
                title: e.target.title,
                description: e.target.desc,
                showPointer: true,
                titleAction: null,
                titleClickHandler: null
            });
        currInfobox.setOptions({ visible: true });
        map.entities.push(currInfobox);
    }
}

//Clear the Map
function clearMap() {
    searchResultPage = 0;
    map.entities.clear();
    Microsoft.Maps.Events.removeHandler(click);
}

//resize the map
function resize() {
    var mapDiv = document.getElementById("divMap");
    var windowHeight = $(window).height();
    mapHeight = windowHeight - 50;
    mapDiv.style.height = mapHeight + "px";
}

function toggleTL1() {
    if (tl1 == 0) {
        tl1 = 1;
        getTL1();
    }
    else {
        tl1 = 0;
        clearMap();
    }
}

function getTL1() {
    map.setView({ zoom: 9, center: new Microsoft.Maps.Location(-33.360771, 116.155212) });

    var options = { uriConstructor: 'http://donkeystorage.blob.core.windows.net/tiles/AU-Fire/{quadkey}.png', width: 256, height: 256 };
    var tileSource = new Microsoft.Maps.TileSource(options);
    var tilelayer = new Microsoft.Maps.TileLayer({ mercator: tileSource });
    map.entities.push(tilelayer);
}

function toggleTL3() {
    if (tl3 == 0) {
        tl3 = 1;
        click = Microsoft.Maps.Events.addHandler(map, 'click', displayParcelInfo);
        getTL3();
    }
    else {
        tl3 = 0;
        clearMap();
    }
}

function displayParcelInfo(e) {
    if (e.targetType == "map") {
        var point = new Microsoft.Maps.Point(e.getX(), e.getY());
        var loc = e.target.tryPixelToLocation(point);

        map.getCredentials(function (credentials) {
            var sdsRequest =
                baseUrl +
                ds3Id + "/" +
                ds3Name + "/" +
                ds3EntityName +
                "?SpatialFilter=intersects('POINT (" + loc.longitude + " " + loc.latitude + ")')&$format=json&jsonp=displayParcelInfoCallback&key=" + credentials;

            var mapscript = document.createElement('script');
            mapscript.type = 'text/javascript';
            mapscript.src = sdsRequest;
            document.getElementById('divMap').appendChild(mapscript);
        });
    }
}

function displayParcelInfoCallback(result) {
    if (result &&
                result.d &&
                result.d.results &&
                result.d.results.length > 0) {

        var entity = result.d.results[0];
        var geomStyles = { pushpinOptions: { icon: "/images/TS.png", height: 30, width: 22, anchor: new Microsoft.Maps.Point(15, 11) }, polylineOptions: { strokeColor: new Microsoft.Maps.Color(100, 255, 255, 255) }, polygonOptions: { fillColor: new Microsoft.Maps.Color(0, 0, 0, 0), strokeColor: new Microsoft.Maps.Color(100, 255, 0, 0) } };
        var shape = WKTModule.Read(entity.Geom, geomStyles);
        map.entities.push(shape);

        var polyInfobox = new Microsoft.Maps.Infobox(new Microsoft.Maps.Location(result.d.results[0].Latitude, result.d.results[0].Longitude), { title: 'ID: ' + result.d.results[0].EntityID, description: result.d.results[0].AddressLine + "<br>" + result.d.results[0].PostalCode, polygon: shape });
        map.entities.push(polyInfobox);
    }
}

function getTL3() {
    map.setView({ zoom: 16, center: new Microsoft.Maps.Location(47.671150, -122.017540) });

    var options = { uriConstructor: 'http://geoaide.azurewebsites.net/SdsTileServerAzure.ashx?quadkey={quadkey}', width: 256, height: 256 };
    var tileSource = new Microsoft.Maps.TileSource(options);
    var tilelayer = new Microsoft.Maps.TileLayer({ mercator: tileSource });
    map.entities.push(tilelayer);
}

function toggleTL5() {
    if (tl5 == 0) {
        tl5 = 1;
        getTL5();
    }
    else {
        tl5 = 0;
        clearMap();
    }
}

function getTL5() {
    var options = { uriConstructor: 'http://geoaide.azurewebsites.net/SqlTileServerAzure.ashx?quadkey={quadkey}', width: 256, height: 256 };
    var tileSource = new Microsoft.Maps.TileSource(options);
    var tilelayer = new Microsoft.Maps.TileLayer({ mercator: tileSource });
    map.entities.push(tilelayer);
}

//toggle heatmap
function toggleHL1() {
    if (hl1 == 0) {
        hl1 = 1;
        map.setView({
            zoom: 4,
            center: new Microsoft.Maps.Location(39.443256, -98.957336)
        });

        // reset search results array, and pagination global variables:
        searchResultsArray = new Array();
        searchResultsPage = 0;

        Microsoft.Maps.registerModule("HeatMapModule", "./scripts/heatmap.js");
        Microsoft.Maps.loadModule("HeatMapModule", {
            callback: function () {
                //Create a basic heatmap from an array of locations
                heatmapLayer = null;
                getHL1();
            }
        });
    }
    else {
        hl1 = 0;
        removeHeatmapLayer();
    }
}

//get data points for heatmap from SDS
function getHL1() {
    var bounds = map.getTargetBounds();
    var south = bounds.getSouth();
    var north = bounds.getNorth();
    var east = bounds.getEast();
    var west = bounds.getWest();

    map.getCredentials(function (credentials) {
        var sdsRequest =
                    baseUrl +
                    ds4Id + "/" +
                    ds4Name + "/" +
                    ds4EntityName +
                    "?spatialFilter=bbox(" + south + "," + west + "," +
                    north + "," + east + ")" +
                    "&$inlinecount=allpages&$format=JSON&jsonp=ds4Callback" +
                    "&key=" + credentials +
                    "&$top=250&$skip=" + (searchResultPage * 250).toString();

        var mapscript = document.createElement('script');
        mapscript.type = 'text/javascript';
        mapscript.src = sdsRequest;
        document.getElementById('divMap').appendChild(mapscript);

        searchResultPage = searchResultPage + 1;
    });
}

function ds4Callback(result) {
    if (result &&
        result.d &&
        result.d.results &&
        result.d.results.length > 0) {

        // grab search results from response
        searchResultsArray = searchResultsArray.concat(result.d.results);

        // check to see if we need to retrieve more results:
        if (result.d.__count > (searchResultPage * 250)) {
            getHL1();
        } else {
            // Process results:
            // grab search results from response
            var locations = result.d.results;

            // Array to use for heatmap:
            heatmapLocations = new Array();

            for (var j = 0; j < searchResultsArray.length; j++) {
                var location = new Microsoft.Maps.Location(searchResultsArray[j].Latitude, searchResultsArray[j].Longitude);
                heatmapLocations.push(location);
            }

            drawHeatmap();
        }
    }
}

// redraw the heatmap:
function drawHeatmap() {
    // remove heatmap, if present:
    if (heatmapLayer) { removeHeatmapLayer() };

    // Construct heatmap layer, using heatmapping JS module:
    heatmapLayer = new HeatMapLayer(
        map,
        [],
        {
            intensity: hmIntensity,
            radius: hmRadius,
            colourgradient: {
                0.0: 'blue',
                0.25: 'green',
                0.5: 'yellow',
                0.75: 'orange',
                1.0: 'red'
            }
        });
    heatmapLayer.SetPoints(heatmapLocations);
}

// remove heatmap layer, and set to null:
function removeHeatmapLayer() {
    heatmapLayer.Remove();
    heatmapLayer = null;
}

//decoding function for polygons returned from the GeoData API 
function ParseEncodedValue(value) {
    var list = new Array();
    var index = 0;
    var xsum = 0;
    var ysum = 0;
    var max = 4294967296;

    while (index < value.length) {
        var n = 0;
        var k = 0;

        while (1) {
            if (index >= value.length) {
                return null;
            }
            var b = safeCharacters.indexOf(value.charAt(index++));
            if (b == -1) {
                return null;
            }
            var tmp = ((b & 31) * (Math.pow(2, k)));

            var ht = tmp / max;
            var lt = tmp % max;

            var hn = n / max;
            var ln = n % max;

            var nl = (lt | ln) >>> 0;
            n = (ht | hn) * max + nl;
            k += 5;
            if (b < 32) break;
        }

        var diagonal = parseInt((Math.sqrt(8 * n + 5) - 1) / 2);
        n -= diagonal * (diagonal + 1) / 2;
        var ny = parseInt(n);
        var nx = diagonal - ny;
        nx = (nx >> 1) ^ -(nx & 1);
        ny = (ny >> 1) ^ -(ny & 1);
        xsum += nx;
        ysum += ny;
        var lat = ysum * 0.00001;
        var lon = xsum * 0.00001
        list.push(new Microsoft.Maps.Location(lat, lon));
    }
    return list;
}