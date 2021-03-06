using System;
using System.Linq.Expressions;
using AbcYazilim.OgrenciTakip.Model.Entities.Base;

namespace AbcYazilim.OgrenciTakip.UI.Win.Functions
{
    public class FilterFunctions
    {
        public static Expression<Func<T, bool>> Filter<T>(bool aktifKartlariGkoster) where T : BaseEntityDurum
        {
            return x => x.Durum == aktifKartlariGkoster;
        }

        public static Expression<Func<T, bool>> Filter<T>(long id) where T : BaseEntityDurum
        {
            return x => x.Id == id;
        }
}
}