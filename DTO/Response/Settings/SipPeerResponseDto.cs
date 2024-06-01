namespace DTO.Response.Settings
{
    public class SipPeerResponseDto
    {
        public string PeerName { get; set; }
        public object Description { get; set; }
        public bool IsDefaultPeer { get; set; }
        public VoiceHostsResponseDto VoiceHosts { get; set; }
        public string FinalDestinationUri { get; set; }
        public object VoiceHostGroups { get; set; }
        public TerminationHostsResponseDto TerminationHosts { get; set; }
        public CallingNameResponseDto CallingName { get; set; }
        public AddressHostResponseDto Address { get; set; }
        public int PremiseTrunks { get; set; }
    }
}
