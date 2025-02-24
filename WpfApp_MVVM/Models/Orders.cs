//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp_MVVM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.TicketOrders = new HashSet<TicketOrders>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Id_client { get; set; }
        public Nullable<int> Number_order { get; set; }
        public Nullable<System.DateTime> Data_order { get; set; }
        public Nullable<decimal> payment_amount { get; set; }
        public Nullable<int> Id_payment_method { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual PaymentMethods PaymentMethods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketOrders> TicketOrders { get; set; }
    }
}
