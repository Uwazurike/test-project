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
    
    public partial class ClientPaymentMethod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientPaymentMethod()
        {
            this.Payments = new HashSet<Payment>();
        }
    
        public int ClientPaymentMethodID { get; set; }
        public int ClientID { get; set; }
        public int PaymentMethodID { get; set; }
        public string CardNumber { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public string CvC { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
