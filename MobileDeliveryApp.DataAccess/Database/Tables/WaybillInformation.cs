using MobileDeliveryApp.DataAccess.Database.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.DataAccess.Database.Tables
{
    public class WaybillInformation : BaseTableModel
    {
        public int? LoadID { get; set; }
        public int? WaybillID { get; set; }
        public int? FromLocationID { get; set; }
        public int? ToLocationID { get; set; }
        public int? DriverID { get; set; }
        public int? TrackTypeID { get; set; }
        public int? LoadStatusID { get; set; }
        public int? PrimaryLoadID { get; set; }
        public int? BillCustID { get; set; }
        public int? ParcelID { get; set; }
        public string? ScanID { get; set; }
        public DateTime? LoadDate { get; set; }
        public string? Vehicle { get; set; }
        public string? Courier { get; set; }
        public string? LoadStatus { get; set; }
        public string? WaybillNo { get; set; }
        public string? DriverName { get; set; }
        public bool? AllowWaybillScan { get; set; }
        public string? TrackType { get; set; }
        public string? ToBC { get; set; }
        public string? Customer { get; set; }
        public string? Date { get; set; }
        public string? PODDate { get; set; }
        public string? Signee { get; set; }
        public string? ScannedDT { get; set; }
        public string? PODUserID { get; set; }
        public string? Signature { get; set; }
        public string? DeliveryType { get; set; }
        public string? Delivered { get; set; }
        public string? Color { get; set; }
        public string? Completed { get; set; }
        public string? FileName { get; set; }
        public string? Barcode { get; set; }
        public string? ScanDate { get; set; }
        public string? Scanned { get; set; }
        public string? Reason { get; set; }
        public string? Text { get; set; }
        public string? DeviceSerial { get; set; }
        public string? EndorsementID { get; set; }
        public string? Endorsement { get; set; }
        public string? EndorsementTypeID { get; set; }
        public bool? Synchronised { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }
        public decimal? Weight { get; set; }
        public decimal? WaybillWeight { get; set; }
        public decimal? PL { get; set; }
        public decimal? PW { get; set; }
        public decimal? PH { get; set; }
    }
}
