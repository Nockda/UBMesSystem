package kr.co.micube.common.mes.constant;

public class CommonConstant {
	/**************************************
	 * Lot Transit Type
	 **************************************/
	public class TransitType {
		// ReceiveLot
		public final static String ReceiveLot = "ReceiveLot";
		
		// TrackInLot
		public final static String TrackInLot = "TrackInLot";
		
		// TrackOutLot
		public final static String TrackOutLot = "TrackOutLot";
		
		// SendLot
		public final static String SendLot = "SendLot";
	}
	
	/**************************************
	 * Lot Transition Id
	 **************************************/
	public class TransitionId {
		// ReceiveLot
		public final static String ReceiveLot = "ReceiveLot";

		// CancelReceiveLot
		public final static String CancelReceiveLot = "CancelReceiveLot";
		
		// trackIn
		public final static String TrackIn = "trackIn";
		
		// CancelTrackIn
		public final static String CancelTrackIn = "CancelTrackIn";
		
		// TrackOut
		public final static String TrackOut = "TrackOut";
		
		// CancelTrackout
		public final static String CancelTrackOut = "CancelTrackout";
		
		// SendLot
		public final static String SendLot = "SendLot";
		
		// CancelSendLot
		public final static String CancelSendLot = "CancelSendLot";
		
		// MoveDispatchLot
		public final static String MoveDispatchLot = "MoveDispatchLot";
		
		// DispatchLot
		public final static String DispatchLot = "DispatchLot";
		
		// cancelFinishLot
		public final static String CancelFinishLot = "cancelFinishLot";
	}
	
	/**************************************
	 * Lot State
	 **************************************/
	public class LotState{
		// Created
		public final static String Created = "Created";
		
		// InProduction
		public final static String InProduction = "InProduction";
		
		// InTransit
		public final static String InTransit = "InTransit";
		
		// Finished
		public final static String Finished = "Finished";
		
		// Consumed 
		public final static String Consumed = "Consumed";
		
		// Shipped 
		public final static String Shipped = "Shipped";
		
		// Terminated
		public final static String Terminated = "Terminated";
		
		// InTransitPlant
		public final static String InTransitPlant = "InTransitPlant";
	}
	
	/**************************************
	 * Lot ProcessState
	 **************************************/
	public class LotProcessState{
		// WaitForReceive
		public final static String WaitForReceive = "WaitForReceive";
		
		// Wait
		public final static String Wait = "Wait";
		
		// Run
		public final static String Run = "Run";
		
		// WaitForSend
		public final static String WaitForSend = "WaitForSend";
		
		// WaitForDispatch
		public final static String WaitForDispatch = "WaitForDispatch";
	}
	
	/**************************************
	 * Consumable State
	 **************************************/
	public class ConsumableState{
		// Available
		public final static String Available = "Available";
		
		// Consumed
		public final static String Consumed = "Consumed";
		
		// Scrapped
		public final static String Scrapped = "Scrapped";
	}
	
	/**************************************
	 * Durable State
	 **************************************/
	public class DurableState{
		// Available
		public final static String Available = "Available";
		
		// Cleaning
		public final static String Cleaning = "Cleaning";
		
		// InUse
		public final static String InUse = "InUse";
		
		// Scrapped
		public final static String Scrapped = "Scrapped";
		
		// Repairing
		public final static String Repairing = "Repairing";
	}
	
	/**************************************
	 * EquipmentState State
	 **************************************/
	public class EquipmentState{
		// Run
		public final static String Run = "Run";
		
		// Idle
		public final static String Idle = "Idle";
		
		// Down
		public final static String Down = "Down";
	}
	
	/**************************************
	 * Area Own Type
	 **************************************/
	public class AreaOwnType {
		// 자사
		public final static String OurCompany = "OutCompany";
		
		// 소사
		public final static String MajorSuppliers = "MajorSuppliers";
		
		// 사내외주
		public final static String InHouseOSP = "InHouseOSP";
		
		// 사외외주
		public final static String OutsideOSP = "OutsideOSP";
	}
	
	/**************************************
	 * QTime Action Type
	 **************************************/
	public class QTimeActionType {
		// Hold Lot
		public final static String HoldLot = "HoldLot";
		
		// Locking Lot
		public final static String LockingLot = "LockingLot";
		
		// SendEMail
		public final static String SendEMail = "SendEMail";
		
		// SendSMS
		public final static String SendSMS = "SendSMS";
	}
}