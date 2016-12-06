using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskInsider
{
    [MetadataType(typeof(AddressMetaData))]
    public partial class Address
    {
    }

    public class AddressMetaData
    {
        [DisplayName("Address")]
        public int AddressID { get; set; }

        [DisplayName("Street")]
        [Required(ErrorMessage = "Please enter a Street")]
        [MaxLength(50, ErrorMessage = "Street can't be more than 50 characters")]
        public string StreetAddress { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "A city is required")]
        [MaxLength(50, ErrorMessage = "City name can't be more than 50 characters")]
        public string City { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "A State is required")]
        [MaxLength(50, ErrorMessage = "State name cant be more than 50 characters")]
        public string State { get; set; }

        [DisplayName("Zip")]
        [Required(ErrorMessage = "A ZipCode is required")]
        [MaxLength(50, ErrorMessage = "ZipCode can't be more than 50 characters")]
        public string ZipCode { get; set; }
    }

    [MetadataType(typeof(AddressTypeMetaData))]
    public partial class AddressType
    {
    }

    public class AddressTypeMetaData
    {
        [DisplayName("Address")]
        public int AddressTypeID { get; set; }

        [DisplayName("Address Type")]
        [Required(ErrorMessage = "Please enter an Address Type")]
        [MaxLength(50, ErrorMessage = "Address Type can't be more than 50 characters")]
        public string AddressType1 { get; set; }
    }

    [MetadataType(typeof(ClientMetaData))]
    public partial class Client
    {
    }

    public class ClientMetaData
    {
        [DisplayName("Client")]
        public int ClientID { get; set; }

        [DisplayName("@UserName")]
        [Required(ErrorMessage = "Please enter a Username")]
        [MaxLength(50, ErrorMessage = "Username can't be more than 50 characters")]
        public string UserName { get; set; }

        [DisplayName("First")]
        [Required(ErrorMessage = "A first name is required")]
        [MaxLength(50, ErrorMessage = "First name can't be more than 50 characters")]
        public string ClientFirstName { get; set; }

        [DisplayName("Last")]
        [Required(ErrorMessage = "A last name is required")]
        [MaxLength(50, ErrorMessage = " last name can't be more than 50 characters")]
        public string ClientLastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "An Email is required")]
        [MaxLength(50, ErrorMessage = "Email Address can't be more than 50 characters")]
        public string ClientEmailAddress { get; set; }

        [DisplayName("Phone")]
        [Required(ErrorMessage = "A phone number is required")]
        [MaxLength(50, ErrorMessage = "Phone number cant be more than 50 characters")]
        public string ClientPhoneNumber { get; set; }
    }

    [MetadataType(typeof(ClientAddressMetaData))]
    public partial class ClientAddress
    {
    }

    public class ClientAddressMetaData
    {
        [DisplayName("Client Address")]
        public int ClientAddressID { get; set; }

        [DisplayName("Client")]
        public int ClientID { get; set; }

        [DisplayName("Address")]
        public int AddressID { get; set; }

        [DisplayName("Address Type")]
        public int AddressTypeID { get; set; }
    }

    [MetadataType(typeof(ClientHeaderPhotoMetaData))]
    public partial class ClientHeaderPhoto
    {
    }

    public class ClientHeaderPhotoMetaData
    {
        [DisplayName("Profile Header")]
        public int ClientHeaderPhotoID { get; set; }

        [DisplayName("Client")]
        public int ClientID { get; set; }

        [DisplayName("Header")]
        [MaxLength(50, ErrorMessage = " Image filename can't be more than 50 characters")]
        public string HeaderFileName { get; set; }
    }

    [MetadataType(typeof(PaymentMethodMetaData))]
    public partial class PaymentMethod
    {
    }

    public class PaymentMethodMetaData
    {
        [DisplayName("Payment Method")]
        public int PaymentMethodID { get; set; }

        [DisplayName("Payment Method")]
        [Required(ErrorMessage = "Create a payment method name")]
        [MaxLength(50, ErrorMessage = "Payment method name cant be more than 50 characters")]
        public string PaymentMethod1 { get; set; }
    }

    [MetadataType(typeof(ClientPaymentMethodMetaData))]
    public partial class ClientPaymentMethod
    {
    }

    public class ClientPaymentMethodMetaData
    {
        [DisplayName("Payment Method")]
        public int ClientPaymentMethodID { get; set; }

        [DisplayName("Client")]
        public int ClientID { get; set; }

        [DisplayName("Payment Method")]
        public Nullable<int> PaymentMethodID { get; set; }

        [DisplayName("Card Number")]
        [Required(ErrorMessage = "A Card number is required")]
        [MaxLength(16, ErrorMessage = "Card number cant be more than 16 characters")]
        public string CardNumber { get; set; }

        [DisplayName("Expiration Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "An Expiration date is required")]
        public System.DateTime ExpirationDate { get; set; }

        [DisplayName("CVC")]
        [Required(ErrorMessage = "A Card CVC is required")]
        [MaxLength(4, ErrorMessage = "Card CVC cant be more than 4 characters")]
        public string CvC { get; set; }
    }

    [MetadataType(typeof(ClientPaymentStatuMetaData))]
    public partial class ClientPaymentStatu
    {
    }

    public class ClientPaymentStatuMetaData
    {
        [DisplayName("Payment Status")]
        public int ClientPaymentStatusID { get; set; }

        [DisplayName("Client Payment Status")]
        [Required(ErrorMessage = "Please enter a Payment Status")]
        [MaxLength(50, ErrorMessage = "Status can't be more than 50 characters")]
        public string ClientPaymentStatus { get; set; }
    }

    [MetadataType(typeof(ClientPhotoMetaData))]
    public partial class ClientPhoto
    {
    }

    public class ClientPhotoMetaData
    {
        [DisplayName("Profile Image")]
        public int ClientPhotoID { get; set; }

        [DisplayName("Client")]
        public int ClientID { get; set; }

        [DisplayName("Profile Image")]
        [MaxLength(50, ErrorMessage = " Image filename can't be more than 50 characters")]
        public string PhotoFileName { get; set; }
    }

    [MetadataType(typeof(ClientProfileMetaData))]
    public partial class ClientProfile
    {
    }

    public class ClientProfileMetaData
    {
        [DisplayName("Client Profile")]
        public int ClientProfileID { get; set; }

        [DisplayName("Client")]
        public int ClientID { get; set; }
    }

    [MetadataType(typeof(ClientProfileModuleMetaData))]
    public partial class ClientProfileModule
    {
    }

    public class ClientProfileModuleMetaData
    {
        [DisplayName("Module")]
        public int ClientProfileModuleID { get; set; }

        [DisplayName("Profile")]
        public int ClientProfileID { get; set; }

        [DisplayName("Profile Image")]
        public int ClientPhotoID { get; set; }

        [DisplayName("Header Image")]
        public int ClientHeaderPhotoID { get; set; }
    }

    [MetadataType(typeof(InsiderMetaData))]
    public partial class Insider
    {
    }

    public class InsiderMetaData
    {
        [DisplayName("Insider")]
        public int InsiderID { get; set; }

        [DisplayName("@UserName")]
        [Required(ErrorMessage = "Please enter a Username")]
        [MaxLength(50, ErrorMessage = "Username can't be more than 50 characters")]
        public string UserName { get; set; }

        [DisplayName("First")]
        [Required(ErrorMessage = "A first name is required")]
        [MaxLength(50, ErrorMessage = "First name can't be more than 50 characters")]
        public string InsiderFirstName { get; set; }

        [DisplayName("Last")]
        [Required(ErrorMessage = "A last name is required")]
        [MaxLength(50, ErrorMessage = " last name can't be more than 50 characters")]
        public string InsiderLastName { get; set; }

        [DisplayName("Address")]
        public int AddressID { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "An Email is required")]
        [MaxLength(50, ErrorMessage = "Email Address can't be more than 50 characters")]
        public string InsiderEmailAddress { get; set; }

        [DisplayName("Phone")]
        [Required(ErrorMessage = "A phone number is required")]
        [MaxLength(50, ErrorMessage = "Phone number cant be more than 50 characters")]
        public string InsiderPhoneNumber { get; set; }
    }

    [MetadataType(typeof(InsiderPayInfoMetaData))]
    public partial class InsiderPayInfo
    {
    }

    public class InsiderPayInfoMetaData
    {
        [DisplayName("Banking Info")]
        public int InsiderPayInfoID { get; set; }

        [DisplayName("Insider")]
        public int InsiderID { get; set; }

        [DisplayName("Bank Name")]
        [Required(ErrorMessage = "A Bank Name is required")]
        [MaxLength(50, ErrorMessage = "Bank Name can't be more than 50 characters")]
        public string BankName { get; set; }

        [DisplayName("Routing Number")]
        [Required(ErrorMessage = "A routing number is required")]
        [MaxLength(50, ErrorMessage = "routing Number can't be more than 50 characters")]
        public string RoutingNumber { get; set; }

        [DisplayName("Account Number")]
        [Required(ErrorMessage = "An account number is required")]
        [MaxLength(50, ErrorMessage = "account number can't be more than 50 characters")]
        public string AccountNumber { get; set; }
    }

    [MetadataType(typeof(InsiderPayStatuMetaData))]
    public partial class InsiderPayStatu
    {
    }

    public class InsiderPayStatuMetaData
    {
        [DisplayName("pay Status")]
        public int InsiderPayStatusID { get; set; }

        [DisplayName("Commision Status")]
        [Required(ErrorMessage = "Please enter a Payment Status")]
        [MaxLength(50, ErrorMessage = "Pay Status can't be more than 50 characters")]
        public string InsiderPayStatus { get; set; }
    }

    [MetadataType(typeof(InsiderPhotoMetaData))]
    public partial class InsiderPhoto
    {
    }

    public class InsiderPhotoMetaData
    {
        [DisplayName("Profile Image")]
        public int InsiderPhotoID { get; set; }

        [DisplayName("Insider")]
        public int InsiderID { get; set; }

        [DisplayName("Profile Image")]
        [MaxLength(50, ErrorMessage = " Image filename can't be more than 50 characters")]
        public string PhotoFileName { get; set; }
    }

    [MetadataType(typeof(InsiderProfileMetaData))]
    public partial class InsiderProfile
    {
    }

    public class InsiderProfileMetaData
    {
        [DisplayName(" Insider Profile")]
        public int InsiderProfileID { get; set; }

        [DisplayName("Insider")]
        public int InsiderID { get; set; }
    }

    [MetadataType(typeof(InsiderProfileModuleMetaData))]
    public partial class InsiderProfileModule
    {
    }

    public class InsiderProfileModuleMetaData
    {
        [DisplayName("Module")]
        public int InsiderProfileModuleID { get; set; }

        [DisplayName("Profile")]
        public int InsiderProfileID { get; set; }

        [DisplayName("Profile Image")]
        public int InsiderPhotoID { get; set; }

        [DisplayName("Header Image")]
        public int InsiderHeaderPhotoID { get; set; }

        [DisplayName("Skill")]
        public int InsiderSkillID { get; set; }
    }

    [MetadataType(typeof(InsiderSkillMetaData))]
    public partial class InsiderSkill
    {
    }

    public class InsiderSkillMetaData
    {
        [DisplayName("Skills")]
        public int InsiderSkillID { get; set; }

        [DisplayName("Insider")]
        public int InsiderID { get; set; }

        [DisplayName("Skill")]
        public int SkillID { get; set; }

        [DisplayName("Level")]
        public int SkillLevelID { get; set; }
    }

    [MetadataType(typeof(PaymentMetaData))]
    public partial class Payment
    {
    }

    public class PaymentMetaData
    {
        [DisplayName("Payment")]
        public int PaymentID { get; set; }

        [DisplayName("Insider")]
        public int ClientPaymentMethodID { get; set; }

        [DisplayName("Service Request")]
        public int ServiceRequestID { get; set; }

        [DisplayName("Payment Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A payment date is required")]
        public System.DateTime PaymentDate { get; set; }

        [DisplayName("Payment Amount")]
        [Required(ErrorMessage = "Please enter payment amount")]
        [MaxLength(50, ErrorMessage = "Amount can't be more than 50 characters")]
        public decimal PaymentAmount { get; set; }

        [DisplayName("Terms & Conditions")]
        [Required(ErrorMessage = "Please enter terms")]
        [MaxLength(50, ErrorMessage = "Terms can't be more than 50 characters")]
        public string TermsOfService { get; set; }
    }

    [MetadataType(typeof(RequestStatusMetaData))]
    public partial class RequestStatus
    {
    }

    public class RequestStatusMetaData
    {
        [DisplayName("Status")]
        public int RequestStatusID { get; set; }

        [DisplayName("Request Status")]
        [Required(ErrorMessage = "Please enter request Status")]
        [MaxLength(50, ErrorMessage = "Request status can't be more than 50 characters")]
        public string RequestStatus { get; set; }
    }

    [MetadataType(typeof(ServiceMetaData))]
    public partial class Service
    {
    }

    public class ServiceMetaData
    {
        [DisplayName("Service")]
        public int ServiceID { get; set; }

        [DisplayName("Category")]
        public int ServiceTypeID { get; set; }

        [DisplayName("Insider")]
        public int InsiderID { get; set; }

        [DisplayName("Service Name")]
        [Required(ErrorMessage = "Please enter service name")]
        [MaxLength(50, ErrorMessage = "Service name can't be more than 50 characters")]
        public string ServiceName { get; set; }

        [DisplayName("Rate")]
        [Required(ErrorMessage = "Please enter hourly rate")]
        //[MaxLength(50, ErrorMessage = "rate can't be more than 50 characters")]
        public decimal HourlyRate { get; set; }

        [DisplayName("Min Hours")]
        [Required(ErrorMessage = "Minimum Bookable hours is required")]
        //[MaxLength(50, ErrorMessage = "Bookable hours can't be more than 50 characters")]
        public int MinBookableHours { get; set; }

        [DisplayName("Service Fee (in %)")]
        [Description("This amount will be deducted from insider earnings. Enter without % sign")]
        [Required(ErrorMessage = "Enter a percentage without %")]
        //[MaxLength(50, ErrorMessage = "Percentage can't be more than 50 characters")]
        public decimal ServiceCharge { get; set; }
    }

    [MetadataType(typeof(ServiceOrderItemsMetaData))]
    public partial class ServiceOrderItems
    {
    }

    public class ServiceOrderItemsMetaData
    {
        [DisplayName("Order Items")]
        public int ServiceOrderItemsID { get; set; }

        [DisplayName("Order")]
        public int OrderID { get; set; }
    }

    [MetadataType(typeof(ServiceRequestMetaData))]
    public partial class ServiceRequest
    {
    }

    public class ServiceRequestMetaData
    {
        [DisplayName("Service Request")]
        public int ServiceRequestID { get; set; }

        [DisplayName("Client")]
        public int ClientID { get; set; }

        [DisplayName("Related Request")]
        public int RelatedServiceRequestID { get; set; }

        [DisplayName("Service")]
        public int ServiceID { get; set; }

        [DisplayName("Insider")]
        public int InsiderID { get; set; }

        [DisplayName("Hours Over Min")]
        [Description("Hours worked, that is over minimum hours booked leave blank if service is ongoing")]
        //[MaxLength(50, ErrorMessage = "Hours over minimum hours can't be more than 50 characters")]
        public int? HoursOverMinimum { get; set; }

        [DisplayName("Total Hours")]
        [Description("Min Hours + Hours Over Min or enter only Min Hours if service is ongoing")]
        [Required(ErrorMessage = "Please enter final total or enter Min hours if total is not yet known")]
        //[MaxLength(50, ErrorMessage = "Total hours can't be more than 50 characters")]
        public int TotalHoursWorked { get; set; }

        [DisplayName("Total Amount")]
        [Description("Min hours + Hours Over Min X Hourly Rate or leave blank if service is ongoing")]
       // [MaxLength(50, ErrorMessage = "amount can't be more than 50 characters")]
        public decimal? TotalAmount { get; set; }

        [DisplayName("Amount Payable")]
        [Description("Amt Payable after fee deduction ex. Tot amt = $100 if serv fee = 25% then payable = $75")]
        //[MaxLength(50, ErrorMessage = "amount can't be more than 50 characters")]
        public decimal? FinalEarnings { get; set; }

        [DisplayName("Payment Status")]
        public int ClientPaymentStatusID { get; set; }

        [DisplayName("Request Status")]
        public int RequestStatusID { get; set; }

        [DisplayName("Completion Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ServiceCompletionDate { get; set; }

        [DisplayName("Commision Status")]
        public int InsiderPayStatusID { get; set; }

        [DisplayName("Payout Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> InsiderPayDate { get; set; }
    }

    [MetadataType(typeof(ServiceTypeMetaData))]
    public partial class ServiceType
    {
    }

    public class ServiceTypeMetaData
    {
        [DisplayName("Service Type")]
        public int ServiceTypeID { get; set; }

        [DisplayName("Service Image")]
        [MaxLength(50, ErrorMessage = " Image filename can't be more than 50 characters")]
        public string  ServiceImageFileName { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Please enter category name")]
        [MaxLength(50, ErrorMessage = "Category name can't be more than 50 characters")]
        public string ServiceTypeName { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Please enter a category description")]
        [MaxLength(50, ErrorMessage = "Description can't be more than 50 characters")]
        public string ServiceTypeDescription { get; set; }
    }

    [MetadataType(typeof(SkillMetaData))]
    public partial class Skill
    {
    }

    public class SkillMetaData
    {
        [DisplayName("Skills")]
        public int SkillID { get; set; }

        [DisplayName("Skills")]
        [Required(ErrorMessage = "Add a skill")]
        [MaxLength(50, ErrorMessage = "Skill can't be more than 50 characters")]
        public string SkillName { get; set; }
    }

    [MetadataType(typeof(SkillLevelMetaData))]
    public partial class SkillLevel
    {
    }

    public class SkillLevelMetaData
    {
        [DisplayName("Level")]
        public int SkillLevelID { get; set; }

        [DisplayName("Skill Level")]
        [Required(ErrorMessage = "Add a Skill Level")]
        [MaxLength(50, ErrorMessage = "Skill can't be more than 50 characters")]
        public string SkillLevelName { get; set; }
    }

    [MetadataType(typeof(UserTypeMetaData))]
    public partial class UserType
    {
    }

    public class UserTypeMetaData
    {
        [DisplayName("User Type")]
        public int UserTypeID { get; set; }

        [DisplayName("Client")]
        public int ClientID { get; set; }

        [DisplayName("Insider")]
        public int InsiderID { get; set; }
    }

}