using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Population_Database_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        decimal totalPopulation; //create variables to hold the values
        decimal average;
        decimal highestPopulation;
        decimal lowestPopulation;

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.populationDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'populationDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.populationDataSet.City);

        }

        private void ascendingButton_Click(object sender, EventArgs e) //sorts the cities by ascending order of population
        {
            this.cityTableAdapter.FillByPopulation(this.populationDataSet.City);
        }

        private void descendingButton_Click(object sender, EventArgs e) //sorts the cities by descending order of population
        {
            this.cityTableAdapter.FillByDescendingPopulation(this.populationDataSet.City);
        }

        private void alphabeticalButton_Click(object sender, EventArgs e) //sorts the cities by alphabetical order
        {
            this.cityTableAdapter.FillByAlphabetical(this.populationDataSet.City);
        }

        private void button3_Click(object sender, EventArgs e) // gets the total population amount 
        {
            //decimal totalPopulation;

            totalPopulation = (decimal)this.cityTableAdapter.TotalPopulation();
            MessageBox.Show("Total population is " + totalPopulation.ToString("n"));
        }

        private void averageButton_Click(object sender, EventArgs e) //gets the average population
        {
            //decimal average;
            average = (decimal)this.cityTableAdapter.AveragePopulation();
            MessageBox.Show("Average population is " + average.ToString("n"));
        }

        private void highestPopulationButton_Click(object sender, EventArgs e) //gets the highest population from the data
        {
            //decimal highestPopulation;
            highestPopulation = (decimal)this.cityTableAdapter.HighestPopulation();
            MessageBox.Show("Highest population is "+highestPopulation.ToString("n"));
        }

        private void lowestPopulationButton_Click(object sender, EventArgs e) //gets the lowest population from the data
        {
            //decimal lowestPopulation;
            lowestPopulation = (decimal)this.cityTableAdapter.LowestPopulation();
            MessageBox.Show("Lowest population is "+lowestPopulation.ToString("n"));
        }

        private void displayInfoButton_Click(object sender, EventArgs e) //prints out all the information asked
        {

            totalPopulation = (decimal)this.cityTableAdapter.TotalPopulation();
            average = (decimal)this.cityTableAdapter.AveragePopulation();
            highestPopulation = (decimal)this.cityTableAdapter.HighestPopulation();
            lowestPopulation = (decimal)this.cityTableAdapter.LowestPopulation();


            MessageBox.Show("Total population is " + totalPopulation.ToString("n") + "\nAverage population is " + average.ToString("n") +
                "\nHighest population is " + highestPopulation.ToString("n") + "\nLowest population is " + lowestPopulation.ToString("n"));
            
        }
    }
}
