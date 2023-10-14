using System;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace SerializationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnJSONWrite_Click(object sender, EventArgs e)
        {
            try
            {
                // step 1 - store data in the object

                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);

                // step 2

                FileStream fs = new FileStream(@"D:\Serialization\emp.json", FileMode.Create, FileAccess.Write);

                // step3
                JsonSerializer.Serialize<Employee>(fs, employee);
                fs.Close();
                MessageBox.Show("Done");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }




        }

        private void btnSOAPRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\Serialization\emp.soap", FileMode.Open, FileAccess.Read);

                
                Employee employee = new Employee();
                SoapFormatter sf = new SoapFormatter();

                employee = (Employee)sf.Deserialize(fs);

                txtId.Text = employee.Id.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

        }

        private void btnSOAPWrite_Click(object sender, EventArgs e)
        {

            try
            {
                // step 1 - store data in the object

                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);

                // step 2

                FileStream fs = new FileStream(@"D:\Serialization\emp.soap", FileMode.Create, FileAccess.Write);

                // step3
                SoapFormatter sf = new SoapFormatter();

                sf.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);


                FileStream fs = new FileStream(@"D:\Serialization\emp.dat", FileMode.Create, FileAccess.Write);


                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            
            
            }
        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\Serialization\emp.dat", FileMode.Open, FileAccess.Read);

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Employee employee = new Employee();

                employee = (Employee)binaryFormatter.Deserialize(fs);

                txtId.Text = employee.Id.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }



        }

        private void btnXmlWrite_Click(object sender, EventArgs e)
        {
            try
            {
                // step 1 - store data in the object

                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);

                // step 2

                FileStream fs = new FileStream(@"D:\Serialization\emp.xml", FileMode.Create, FileAccess.Write);

                // step3
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));

                xmlSerializer.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

        }

        private void btnXmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                // step1 - read data from file

                FileStream fs = new FileStream(@"D:\Serialization\emp.xml", FileMode.Open, FileAccess.Read);
                // step2- deserialized

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));

                Employee employee = new Employee();

                employee = (Employee)xmlSerializer.Deserialize(fs);
                // step3- display

                txtId.Text = employee.Id.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

        }

        private void btnJSONRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\Serialization\emp.json", FileMode.Open, FileAccess.Read);


                Employee employee = new Employee();
               // SoapFormatter sf = new SoapFormatter();
                employee = JsonSerializer.Deserialize<Employee>(fs);

              

               // employee = (Employee)sf.Deserialize(fs);

                txtId.Text = employee.Id.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }
    }
}
