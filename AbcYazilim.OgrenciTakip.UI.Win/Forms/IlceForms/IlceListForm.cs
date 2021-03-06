using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Dll.General;
using AbcYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using AbcYazilim.OgrenciTakip.UI.Win.Show;

namespace AbcYazilim.OgrenciTakip.UI.Win.Forms.IlceForms
{
    public partial class IlceListForm : BaseListForm
    {
        #region Variables
        private readonly long _ilId;
        private readonly string _ilAdi;
        #endregion

        public IlceListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new IlceBll();

            _ilId = (long)prm[0];
            _ilAdi = prm[1].ToString();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = grvIlceKartlari;
            BaseKartTuru = KartTuru.Ilce;
            Navigator = longNavigator1.Navigator;
            Text = Text + $" - ( {_ilAdi} )";

        }

        protected override void Listele()
        {
            // Hangi ili gönderdiysek o ile bağlı aktif kartları göster.
            Tablo.GridControl.DataSource = ((IlceBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.IlId == _ilId);
        }

        protected override void ShowEditForm(long id)
        {
            var result = new ShowEditForms<IlceEditForm>().ShowDialogEditForm(KartTuru.Ilce, id, _ilId, _ilAdi);
            ShowEditFormDefault(result);
        }

    }
}