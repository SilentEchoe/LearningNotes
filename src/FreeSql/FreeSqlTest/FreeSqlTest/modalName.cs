using FreeSql.DataAnnotations;
using System;

namespace FreeSqlTest
{
    [Table(Name = "conf_modal_name")]
    public class modalName
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        public string ModalName { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
