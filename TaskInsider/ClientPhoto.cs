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
    
    public partial class ClientPhoto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientPhoto()
        {
            this.ClientProfileModules = new HashSet<ClientProfileModule>();
        }
    
        public int ClientPhotoID { get; set; }
        public int ClientID { get; set; }
        public string PhotoFileName { get; set; }
    
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientProfileModule> ClientProfileModules { get; set; }
    }
}
