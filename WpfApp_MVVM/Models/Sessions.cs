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
    
    public partial class Sessions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sessions()
        {
            this.Tickets = new HashSet<Tickets>();
            this.Tickets1 = new HashSet<Tickets>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> Data_session { get; set; }
        public Nullable<System.TimeSpan> Time_session { get; set; }
        public Nullable<int> Id_hall { get; set; }
        public Nullable<int> Id_movie { get; set; }
    
        public virtual Halls Halls { get; set; }
        public virtual Movies Movies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets1 { get; set; }
    }
}
