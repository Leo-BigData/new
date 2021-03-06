cordova.define("com.phonegap.plugins.PushPlugin.PushPlugin", function (require, exports, module) { // Copyright (c) Microsoft Open Technologies, Inc.  Licensed under the MIT license. 

    module.exports = {
        register: function (success, fail, args) {
            try {
                var onNotificationReceived = window[args[0].ecb];

                Windows.Networking.PushNotifications.PushNotificationChannelManager.createPushNotificationChannelForApplicationAsync().then(
                    function (channel) {
                        channel.addEventListener("pushnotificationreceived", onNotificationReceived);
                        success(channel);
                    }, fail);
            } catch (ex) {
                fail(ex);
            }
        }
    };
    //require("cordova/windows/commandProxy").add("PushPlugin", module.exports);

    require("cordova/exec/proxy").add("PushPlugin", module.exports);
});
