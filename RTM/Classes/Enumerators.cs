using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTM.Classes
{
    public enum TenderingIndex
    {
        TechnicalSpecification = 1,
        PrivateConditions = 2,
        CreditControl = 3,
        CeoOrder = 4,
        CommitteDicision = 5,
        Documents = 6,
        Advertisement = 7,
        ExtendMeetingCommittee = 8,
        ExtendMeetingApplicant = 9,
        ExtendMeeting = 10,
        BriefingMeeting = 11,
        ContractorRecieveDoc = 12,
        ExtendDocMeetingCommittee = 13,
        ExtendDocMeetingApplicant = 14,
        ExtendDocMeeting = 15,
        PacketPresent = 16,
        OpenPacketOne = 17,
        Result = 18,
        OpenPacketTwo = 19,
        WinnerForContract =20,
        Bidding = 32,
        WarrantyMeeting = 33,
        WarrantyDocs = 34,
        TechincalCommitteeMeeting=35,
        BiddingCommitteeMeeting =36,
        OpenPacketIntroductionLetter =37
    }
    public enum MeetingTypes
    {
        PacketExtendingMeeting = 1,
        BriefingMeeting = 2,
        DocExtendingMeeting = 3,
        OnePhaseOpenPacket = 4,
        TwoPhaseOpenPacket = 5
    }

    public enum WarrantyTypes
    {
        LC = 1,
        Draft = 2,
        Stock = 3
    }

    public enum ContractIndex
    {
        _25Percent =1,
        ComplementOrExtend =2

    }
    public enum Stages
    {
        Request = 1,
        CreditControl = 2,
        CEO = 3,
        TenderingMeeting = 4,
        Documents = 5,
        Notice = 6,
        RecieveDocs = 7,
        RecivePackets = 8,
        OpenPacket = 9,
        Warranty = 10,
        Bid = 11,
        Result = 12,
        End = 13
    }
}
