using System.Collections.Generic;

namespace OCR.Core.Helpers
{
    public class Constants
    {
        public const string PLATE_LOGGED_KEY = "PlateLogged";
        public const string LOW_BATTERY_ALERT = "LowBatteryAlert";
        public const string GATEWAY_URL_KEY = "GatewayURL";
        public const string GATEWAY_USER_NAME_KEY = "GatewayUserName";
        public const string GATEWAY_PASSWORD_KEY = "GatewayPassword";
        public const string DRIVER_USER_NAME_KEY = "DriverUserName";
        public const string DRIVER_PASSWORD_KEY = "DriverPassword";
        public const string CONFIGURATION_NAME_KEY = "ConfigurationName";
        public const string AUTH_STRING_KEY = "AuthString";
        public const string CLIENT_ID_KEY = "ClientId";
        public const string GATEWAY_ID_KEY = "GatewayId";
        public const string TDID_KEY = "Tdid";
        public const string DEVICE_REGISTERED_KEY = "IsDeviceRegistered";
        public const string VEHICLE_ENTITY_ID = "VehicleEntityId";
        public const string MAX_SPEED = "MaxSpeed";
        public const string SYNC_MAX_ELEMENT_PER_CALL = "SyncMaxElementPerCall";
        public const string SECONDS_TO_SYNC_OFFLINE_DATA_WITH_SERVICE = "SecondsToSyncOfflineDataWithService";
        public const string LAST_MODIFIED_HH_CONFIGURATION = "LastModifiedHHConfigurationUTC";
        public const string LAST_PLATE_LOGGED = "LastPlateLogged";
        public const string SECONDS_TO_CHECK_CONNECTIVITY_STATUS = "SecondsToCheckConnectivityStatus";

        public const string OPERATION_ADD = "add";
        public const string OPERATION_UPDATE = "update";
        public const string OPERATION_DELETE = "delete";
        public const string OPERATION_UNASSIGN = "unassign";

        public const string TOUR_STATUS_ICON_BLUE = "blue_circle.png";
        public const string TOUR_STATUS_ICON_CROSS_OVER_RED = "cross_over_red.png";
        public const string TOUR_STATUS_ICON_GRAY = "gray.png";
        public const string TOUR_STATUS_ICON_GREEN = "trafficlightgreen.png";
        public const string TOUR_STATUS_ICON_RED = "trafficlightred.png";
        public const string TOUR_STATUS_ICON_YELLOW = "trafficlightyellow.png";

        public const float QTY_NO = 0.00f;
        public const float QTY_PARTIAL = 0.01f;

        public static readonly List<string> MissingTicketPatternMatching = new List<string> {"0", "-"};

        public const long DRIVER_ID = 1000;
        public const string DEVICE_ID = null;
    }
}