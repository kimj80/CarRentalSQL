using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmpt291UI
{
    public partial class CustomerWindow : Form
    {
        public class Car
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int Year { get; set; }
            public string Engine { get; set; }
            public string Color { get; set; }
            public Image Image { get; set; }
        }

        private List<Car> cars;
        private int currentCarIndex = 0;
        private System.Windows.Forms.Timer timer1;
        public CustomerWindow()
        {
            InitializeComponent();
            LoadCars();
            InitializeTimer();
            DisplayCarDetails(currentCarIndex);
        }

        private void LoadCars()
        {
            string imgPath = @"C:\Users\Jae\Desktop\Car-Rental-System-Jae\img";
            cars = new List<Car>
            {
            new Car { Name = "Honda Accord", Type = "Sedan", Year = 2020, Engine = "Gas", Color = "Black", Image = LoadImage(Path.Combine(imgPath, "Honda_Accord_2020_Black.jpg"))},
            new Car { Name = "Volkswagen Beetle", Type = "Sedan", Year = 2019, Engine = "Gas", Color = "White", Image = LoadImage(Path.Combine(imgPath, "Volkswagen_Beetle_2019_White.jpg"))},
            new Car { Name = "Chevrolet Volt", Type = "Sedan", Year = 2023, Engine = "Electric", Color = "White", Image = LoadImage(Path.Combine(imgPath, "Chevrolet_Volt_2023_White.jpg"))},
            new Car { Name = "BMW X5", Type = "SUV", Year = 2023, Engine = "Gas", Color = "Black", Image = LoadImage(Path.Combine(imgPath, "BMW_X5_2023_Black.jpg"))},
            new Car { Name = "Ford F-150", Type = "Truck", Year = 2019, Engine = "Gas", Color = "Blue", Image = LoadImage(Path.Combine(imgPath, "Ford_F-150_2019_Blue.jpg"))},
            new Car { Name = "Ford Mustang", Type = "Sport", Year = 2023, Engine = "Gas", Color = "Grey", Image = LoadImage(Path.Combine(imgPath, "Ford_Mustang_2023_Grey.jpg"))},
            new Car { Name = "Lincoln Navigator", Type = "SUV", Year = 2022, Engine = "Gas", Color = "Blue", Image = LoadImage(Path.Combine(imgPath, "Lincoln_Navigator_ 2022_Blue.jpg"))},
            new Car { Name = "Rivian R1T", Type = "Truck", Year = 2024, Engine = "Electric", Color = "White", Image = LoadImage(Path.Combine(imgPath, "Rivian_R1T_2024_White.jpg"))},
            };  
        
        }

        private void InitializeTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 5000; // 5 seconds
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            timer1.Start();
        }

        private Image LoadImage(string path)
        {
            try
            {
                return Image.FromFile(path);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"File not found: {path}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // or a default image
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {path}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // or a default image
            }
        }

        private void DisplayCarDetails(int index)
        {
            if (index < 0 || index >= cars.Count)
                return;

            Car car = cars[index];
            pictureBox1.Image = car.Image;
            CarName.Text = car.Name;
            CarTrim.Text = car.Type;
            CarYear.Text = car.Year.ToString();
            CarEngine.Text = car.Engine;
            CarColor.Text = car.Color;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentCarIndex++;
            if (currentCarIndex >= cars.Count)
                currentCarIndex = 0;
            DisplayCarDetails(currentCarIndex);
        }

   
    }
}
