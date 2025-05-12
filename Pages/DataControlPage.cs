using GreenByte.DataAccess;
using GreenByte.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace greenByte.Pages
{
    public partial class DataControlPage : UserControl
    {
        private SensorDataDataAccess sensordal = new SensorDataDataAccess();
        public DataControlPage()
        {
            InitializeComponent();
            Utils.StyleDataGrid(dataGridViewDatas);
            LoadSensorTypes();
            LoadDatas();
        }
        private void LoadSensorTypes()
        {
            try
            {
                var sensorDal = new SensorDataAccess();
                var seraId = CurrentGreenhouse.Selected?.Id ?? 0;
                var sensors = sensorDal.GetByGreenhouseId(seraId);

                comboBoxSensorType.DataSource = sensors;
                comboBoxSensorType.DisplayMember = "SensorName";
                comboBoxSensorType.ValueMember = "Id";


                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = "Sensör listesi başarıyla yüklendi.",
                    LogTime = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sensör listesi yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = $"Sensör listesi yüklenirken hata oluştu: {ex.Message}",
                    LogTime = DateTime.Now
                });
            }
        }
        private void LoadDatas()
        {
            var seraId = CurrentGreenhouse.Selected?.Id ?? 0;
            var selectedSensorId = 0;
            if (comboBoxSensorType.SelectedValue != null)
            {
                if (comboBoxSensorType.SelectedValue is int)
                {
                    selectedSensorId = (int)comboBoxSensorType.SelectedValue;
                }
                else if (comboBoxSensorType.SelectedValue is GreenByte.Models.Sensor)
                {
                    selectedSensorId = ((GreenByte.Models.Sensor)comboBoxSensorType.SelectedValue).Id;
                }
                else
                {
                    // ValueMember'ı kullanıyorsanız direkt değeri almayı deneyin
                    int.TryParse(comboBoxSensorType.SelectedValue.ToString(), out selectedSensorId);
                }
            }
            DateTime selectedDate = dateTimePickerDatas.Value.Date;
            List<SensorData> filteredDatas;

            // Sensör seçiliyse sensör ID'ye göre filtrele
            if (selectedSensorId > 0)
            {
                filteredDatas = sensordal.GetBySensorIdAndDate(selectedSensorId, selectedDate);
            }
            else
            {
                // Sensör seçilmemişse veya geçersizse, sera ID'ye göre filtrele
                filteredDatas = sensordal.GetDatasByGreenhouseIdAndDate(seraId, selectedDate);
            }

            dataGridViewDatas.DataSource = filteredDatas;

            // Sütun ayarları (mevcut kodunuzdaki gibi)
            if (dataGridViewDatas.Columns.Count > 0)
            {
                if (dataGridViewDatas.Columns.Contains("Id"))
                    dataGridViewDatas.Columns["Id"].Visible = false;
                if (dataGridViewDatas.Columns.Contains("SensorId"))
                    dataGridViewDatas.Columns["SensorId"].Visible = false;
                if (dataGridViewDatas.Columns.Contains("Value"))
                    dataGridViewDatas.Columns["Value"].HeaderText = "Değer";
                if (dataGridViewDatas.Columns.Contains("RecordTime"))
                {
                    dataGridViewDatas.Columns["RecordTime"].HeaderText = "Kayıt Zamanı";
                    dataGridViewDatas.Columns["RecordTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dataGridViewDatas.Columns["RecordTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (dataGridViewDatas.Columns.Contains("SensorName"))
                    dataGridViewDatas.Columns["SensorName"].HeaderText = "Sensör";
            }
        }


        private void comboBoxSensorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDatas();
        }

        private void DataControlPage_Load(object sender, EventArgs e)
        {
            LoadDatas();
        }

        private void dateTimePickerDatas_ValueChanged(object sender, EventArgs e)
        {
            LoadDatas();
        }
    }
}