namespace Domain.Entities
{
    public class Clients :IEntity
    {
        public int Id { get; set; }       
        public string cad_number { get; set; }
        public DateTime? cad_date { get; set; }
        public string call_type { get; set; }
        public string agency_segment { get; set; }
        public string call_status { get; set; }
        public string dismissed_event { get; set; }
        public string cancellation_reason { get; set; }
        public string line { get; set; }
        public string caller_id { get; set; }
        public string caller_number { get; set; }
        public string callback_number { get; set; }
        public string family_last_name { get; set; }
        public string family_first_name { get; set; }       
        public string hebrew_name { get; set; }       
        public string parent_name { get; set; }        
        public string CallReceivedTime { get; set; }        
        public string AssignedTime { get; set; }        
        public string EnRouteTime { get; set; }        
        public string OnSceneTime { get; set; }        
        public string FromSceneTime { get; set; }        
        public string DestinationTime { get; set; }        
        public string InServiceTime { get; set; }        
        public string BackHomeTime { get; set; }        
        public string PdDispatchedTime { get; set; }        
        public string AlsDispatchedTime { get; set; } 
        public string call_location { get; set; }
        public string pickup_address { get; set; }
        public string pickup_city { get; set; }
        public string pickup_state { get; set; }
        public string pickup_zip { get; set; }        
        public string Hospital { get; set; }        
        public string bus_number { get; set; }        
        public string units { get; set; }                
        public string medics { get; set; }        
        public string driver { get; set; }        
        public string unitsSceneOnly { get; set; }       
        public string pt_last_name { get; set; }       
        public string pt_first_name { get; set; }        
        public string pt_age { get; set; }        
        public string pt_Gender { get; set; }        
        public string pt_phone { get; set; }       
        public string pt_floor { get; set; }
        public decimal? pickup_latitude { get; set; }
        public decimal? pickup_longitude { get; set; }
        public string Gps_Link { get; set; }
        public string Cross1 { get; set; }        
        public string cross_street { get; set; }        
        public string Cross2 { get; set; }        
        public string cross_street2 { get; set; }        
        public string message { get; set; }        
        public string title { get; set; }        
        public string detail { get; set; }
        public int? max_member_count { get; set; }
        public int? max_als_count { get; set; }
        public int? max_driver_count { get; set; }
        public int? contact_id { get; set; }
        public int? callLocationId { get; set; }
        public bool is_notification_sent { get; set; }        
        public string external_file_name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? StatusInfoId { get; set; }
        public StatusInfo StatusInfo { get; set; }
        public int? HospitalRelationId { get; set; }
        public bool isCode1 { get; set; }
        public int? PlaceId { get; set; }
        public bool? IsTracking { get; set; }
        public DateTime? LastTrackDate { get; set; }
        public bool Is3rdPartyCall { get; set; }
        public bool IsContactAddressSet { get; set; }
        public string CallInfoText { get; set; }
        public string TrackingToken { get; set; }
        public bool IsAllowLocation { get; set; }
        public string CreatedType { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsCovered { get; set; }
        public bool IsPickup { get; set; }
        public bool UseCallback { get; set; }
        public string OptValues { get; set; }
        public int? CreativeStatusInfoId { get; set; }
        public bool ShareWithMembers { get; set; } = true;
        public int? KjfdIncidentId { get; set; }
        public string UniqueCallId { get; set; }
        public string Note { get; set; }        
        public string ApprovedBy { get; set; }
        public bool? Pd { get; set; }
        public bool PcrOn { get; set; }
        public string LocalCadNumber { get; set; }        
        public string MappedCallStatus { get; set; }
        public bool IsCallStatusManual { get; set; }
        public bool IsTransferred { get; set; }
        public bool IsAcknowledged { get; set; }        
        public int? TransferredFrom { get; set; }
        public int? TransferredTo { get; set; }        
        public string TransferId { get; set; }
        public virtual ICollection<ClientMembers> ClientMembers { get; set; }
        public virtual ICollection<ClientMessages> ClientMessages { get; set; }
        public virtual CallLocation CallLocation { get; set; }
        public virtual Hospital HospitalRelation { get; set; }
    
    }
}
