//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskInsider
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientAddress
    {
        public int ClientAddressID { get; set; }
        public int ClientID { get; set; }
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual Client Client { get; set; }
    }
}
