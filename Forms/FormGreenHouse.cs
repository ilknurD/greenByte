using System;
using System.Windows.Forms;
using GreenByte.Models;
using GreenByte.DataAccess;

namespace greenByte.Forms
{
    public partial class FormGreenhouse : Form
    {
        public GreenHouseModel Greenhouse { get; private set; }
        private bool isEditing = false;

        // Tekil form örneği
        private static FormGreenhouse instance;

        // Formun tek bir örneğini sağlamak için
        public static FormGreenhouse GetInstance(GreenHouseModel greenhouse = null)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormGreenhouse(greenhouse);
            }
            return instance;
        }

        // Parametresiz Constructor
        public FormGreenhouse()
        {
            InitializeComponent();
            Greenhouse = new GreenHouseModel();
            this.Text = "Yeni Sera Ekle";

            // Olayı kaldır ve bir daha ekle
            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;

            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Yeni sera ekleme formu açıldı.",
                LogTime = DateTime.Now
            });
        }

        // Parametreli Constructor
        public FormGreenhouse(GreenHouseModel greenhouse)
        {
            InitializeComponent();
            Greenhouse = greenhouse;
            isEditing = true;
            this.Text = "Sera Düzenle";

            // Olayı kaldır ve bir daha ekle
            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;

            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = $"Sera düzenleme formu açıldı. Sera ID: {greenhouse.Id}",
                LogTime = DateTime.Now
            });

            LoadGreenhouseData();
        }

        private void LoadGreenhouseData()
        {
            if (Greenhouse != null)
            {
                txtGHName.Text = Greenhouse.Name;
                txtGHLocation.Text = Greenhouse.Location;

                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = $"Sera verileri yüklendi. Sera: {Greenhouse.Name}",
                    LogTime = DateTime.Now
                });
            }
        }

        private void FormGreenhouse_Load(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                dateTimePickerKurulusTarihi.Value = DateTime.Now;

                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = "Yeni sera için varsayılan kuruluş tarihi ayarlandı",
                    LogTime = DateTime.Now
                });
            }
            else
            {
                LoadGreenhouseData();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Form kapatma düğmesine tıklandı",
                LogTime = DateTime.Now
            });

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Form kapatılıyor",
                LogTime = DateTime.Now
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGHName.Text))
            {
                MessageBox.Show("Sera adı boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Sera kaydetme işlemi başarısız: Sera adı boş bırakıldı",
                    LogTime = DateTime.Now
                });
                return;
            }

            try
            {
                string action = isEditing ? "güncellendi" : "oluşturuldu";

                Greenhouse.Name = txtGHName.Text;
                Greenhouse.Location = txtGHLocation.Text;
                Greenhouse.UserId = CurrentUser.Id;

                var greenhouseDal = new GreenHouseDataAccess();

                if (isEditing)
                {
                    greenhouseDal.Update(Greenhouse);
                }
                else
                {
                    greenhouseDal.Add(Greenhouse);
                }

                MessageBox.Show("Sera başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = $"Sera {action} başarılı. Sera Adı: {Greenhouse.Name}",
                    LogTime = DateTime.Now
                });

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = $"Sera kaydetme sırasında hata: {ex.Message}",
                    LogTime = DateTime.Now
                });
            }
        }
    }
}
