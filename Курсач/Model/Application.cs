//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Курсач.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Application
    {
        public int DocumentId { get; set; }
        public System.DateTime DocumentDate { get; set; }
        public int ServiceId { get; set; }
        public Nullable<System.DateTime> ApplicationDate { get; set; }
        public int PayWayId { get; set; }
    
        public virtual PayWay PayWay { get; set; }
        public virtual Service Service { get; set; }
        public virtual Document Document { get; set; }
    }
}
