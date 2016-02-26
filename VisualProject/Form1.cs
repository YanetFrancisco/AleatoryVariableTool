using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AleatoryVariableTool;
using System.Windows.Forms.DataVisualization.Charting;

namespace VisualProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {   
            InitializeComponent();
            distribucion.Items.Add(new UniformVariable());
            //distribucion.Items.Add(new ExponentialVariable());
            //distribucion.Items.Add(new NormalVariable());
            distribucion.Items.Add(new PoissonVariable());
            distribucion.SelectedIndex = 0;
        }

        private void distribucion_SelectedValueChanged(object sender, EventArgs e)
        {
            var dist = distribucion.SelectedItem;
            if (dist is UniformVariable)
            {
                label_parametro1.Text = "a";
                label_parametro1.Enabled = true;
                label_parametro2.Text = "b";
                label_parametro2.Enabled = true;
                parametro1_n.Value = 0;
                parametro1_n.Enabled = true;
                parametro2_n.Value = 1;
                parametro2_n.Enabled = true;
                ho.Enabled = true;
                ha.Enabled = true;
                respuesta.Enabled = true;
            }
            else if (dist is ExponentialVariable)
            {
                label_parametro1.Text = "Lambda";
                label_parametro1.Enabled = true;
                label_parametro2.Text = "Parametro 2";
                label_parametro2.Enabled = false;
                parametro1_n.Value = 15;
                parametro1_n.Enabled = true;
                parametro2_n.Enabled = false;
                ho.Enabled = false;
                ha.Enabled = false;
                respuesta.Enabled = false;
            }
            else if (dist is NormalVariable)
            {
                label_parametro1.Text = "M";
                label_parametro1.Enabled = true;
                label_parametro2.Text = "Sigma^2";
                label_parametro2.Enabled = true;
                parametro1_n.Value = 0;
                parametro1_n.Enabled = true;
                parametro2_n.Value = 1;
                parametro2_n.Enabled = true;
                ho.Enabled = false;
                ha.Enabled = false;
                respuesta.Enabled = false;
            }
            else if (dist is PoissonVariable)
            {
                label_parametro1.Text = "L";
                label_parametro1.Enabled = true;
                label_parametro2.Text = " ";
                label_parametro2.Enabled = false;
                parametro1_n.Value = 0;
                parametro1_n.Enabled = true;
                parametro2_n.Value = 1;
                parametro2_n.Enabled = false;
                ho.Enabled = true;
                ha.Enabled = true;
                respuesta.Enabled = true;
                cant_intervaloss.Enabled = false;
                cant_intervalos.Enabled = false;
            }

        }

        private void generar_Click(object sender, EventArgs e)
        {
            List<double> f = new List<double>();

            histograma.Series.Clear();
            poligono.Series.Clear();
            chart1.Series.Clear();
            AleatoryVariableBase dist = (AleatoryVariableBase)distribucion.SelectedItem;
            if (dist is UniformVariable)
            {
                (dist as UniformVariable).A = (double)parametro1_n.Value;
                (dist as UniformVariable).B = (double)parametro2_n.Value;

                List<double> clases = new List<double>();
                var length = (int)cant_intervaloss.Value;
                var step = (((double)max.Value) - ((double)min.Value)) / ((double)cant_intervaloss.Value);
                var valorActual = (double)min.Value;

                for (int i = 0; i <= length; i++)
                {
                    clases.Add((double)valorActual);
                    valorActual += step;
                }
                var clasesCount = new int[length];
                var total = 0;
                for (int i = 0; i < cantidad_variables.Value; i++)
                {
                    var s = dist.GenerateValue();
                    f.Add(s);
                    for (int j = 0; j < clases.Count - 1; j++)
                    {
                        var primero = (double)clases[j];
                        var segundo = (double)clases[j + 1];
                        if (s > primero && s <= segundo)
                        {
                            clasesCount[j]++;
                        }
                        total++;
                    }
                }
                var s2 = new Series("Poligono \n de \n frecuencia \n acumulada \n", total) { ChartType = SeriesChartType.FastLine };
                var s1 = new Series("Poligono \n de \n frecuencia \n", total) { ChartType = SeriesChartType.FastLine };
                s2.Points.Add(new DataPoint(Math.Round((double)clases[0], 2), 0));
                s1.Points.Add(new DataPoint(Math.Round((double)clases[0], 2), 0));
                var ss = new Series("Test", total) { ChartType = SeriesChartType.Column, ShadowColor = Color.Blue, CustomProperties = "PointWidth = 1"};
                var previo = 0.0;
                for (int i = 0; i < clases.Count - 1; i++)
                {
                    previo += (double)clasesCount[i];
                    var primero = (double)clases[i];
                    var segundo = (double)clases[i + 1];
                    var medio = (primero + segundo) / 2;
                    //var s = new Series(primero + " - " + segundo, total) { ChartType = SeriesChartType.Column };
                    ss.Points.Add(new DataPoint(Math.Round(medio, 2), clasesCount[i]));

                    s2.Points.Add(new DataPoint(Math.Round(medio, 2), clasesCount[i]));
                    s1.Points.Add(new DataPoint(Math.Round(medio, 2), previo));

                }
                histograma.Series.Add(ss);
                s2.Points.Add(new DataPoint(Math.Round((double)clases[clases.Count - 1], 2), 0));
                chart1.Series.Add(s1);
                poligono.Series.Add(s2);

                double[] fe = new double[length];
                int n = 0;
                for (int i = 0; i < clasesCount.Length; i++) n += clasesCount[i];
                for (int i = 0; i < fe.Length -1; i++)
                {
                    var primero = (double)clases[i];
                    var segundo = (double)clases[i + 1];
                    if (dist is UniformVariable)
                    {
                        var Pi = 1.0 / clasesCount.Length;
                        fe[i] = n * Pi;

                        //Verificar que Ei >= 5.
                    }

                    double shi_cuadrado = Shi_Cuadrado(clasesCount, fe);
                    bool bondad_de_ajuste = Region_Critica(shi_cuadrado, (double)alfa.Value, clasesCount.Length, 0);

                    ho.Text = "H0: Las mediciones siguen una distribucion " + dist.ToString() + " para un nivel de significacion de: " + alfa.Value.ToString();
                    ha.Text = "HA: Las mediciones NO siguen una distribucion " + dist.ToString() + " para un nivel de significacion de: " + alfa.Value.ToString();

                    if (bondad_de_ajuste)
                        respuesta.Text = "Respuesta: No existe evidencia suficiente para rechazar H0, o sea, rechazar que las mediciones siguen una distribucion " + dist.ToString() + " para un nivel de significacion de: " + alfa.Value.ToString();
                    else
                        respuesta.Text = "Respuesta: Se reachaza H0, por lo que se acepta HA con una distribucion " + dist.ToString() + " para un nivel de significacion de: " + alfa.Value.ToString();
                }
            }
            else if (dist is PoissonVariable)
            {
                (dist as PoissonVariable).L = (double)parametro1_n.Value;

                List<double> clases = new List<double>();
                var length = ((int)max.Value - (int)min.Value) + 1;
                var step = 1;
                var valorActual = (double)min.Value;

                for (int i = 0; i <= length; i++)
                {
                    clases.Add((double)valorActual);
                    valorActual += step;
                }
                var clasesCount = new int[length];
                var total = 0;
                for (int i = 0; i < cantidad_variables.Value; i++)
                {
                    var s = dist.GenerateValue();
                    f.Add(s);
                    for (int j = 0; j < clases.Count - 1; j++)
                    {
                        var primero = (double)clases[j];
                        var segundo = (double)clases[j + 1];
                        if (s > primero && s <= segundo)
                        {
                            clasesCount[j]++;
                        }
                        total++;
                    }
                }

                var s2 = new Series("Poligono \n de \n frecuencia \n acumulada \n", total) { ChartType = SeriesChartType.FastLine };
                var s1 = new Series("Poligono \n de \n frecuencia \n", total) { ChartType = SeriesChartType.FastLine };
                s2.Points.Add(new DataPoint(Math.Round((double)clases[0], 2), 0));
                s1.Points.Add(new DataPoint(Math.Round((double)clases[0], 2), 0));
                var ss = new Series("Test", total) { ChartType = SeriesChartType.Column, ShadowColor = Color.Blue, CustomProperties = "PointWidth = 1" };
                var previo = 0.0;
                for (int i = 0; i < clases.Count - 1; i++)
                {
                    previo += (double)clasesCount[i];
                    var primero = (double)clases[i];
                    //var segundo = (double)clases[i + 1];
                    //var medio = (primero + segundo) / 2;
                    //var s = new Series(primero + " - " + segundo, total) { ChartType = SeriesChartType.Column };
                    ss.Points.Add(new DataPoint(Math.Round(primero, 2), clasesCount[i]));

                    s2.Points.Add(new DataPoint(Math.Round(primero, 2), clasesCount[i]));
                    s1.Points.Add(new DataPoint(Math.Round(primero, 2), previo));

                }
                histograma.Series.Add(ss);
                s2.Points.Add(new DataPoint(Math.Round((double)clases[clases.Count - 1], 2), 0));
                chart1.Series.Add(s1);
                poligono.Series.Add(s2);

                double[] fe = new double[length];
                int n = 0;
                for (int i = 0; i < clasesCount.Length; i++) n += clasesCount[i];
                for (int i = 0; i < fe.Length - 1; i++)
                {
                    var primero = (double)clases[i];
                    var segundo = (double)clases[i + 1];
                    if (dist is UniformVariable)
                    {
                        var Pi = ProbabiblidadDeIntevalo((int)primero + 1, (int)segundo, (dist as PoissonVariable).L);
                        fe[i] = n * Pi;

                        //Verificar que Ei >= 5.
                    }

                    double shi_cuadrado = Shi_Cuadrado(clasesCount, fe);
                    bool bondad_de_ajuste = Region_Critica(shi_cuadrado, (double)alfa.Value, clasesCount.Length, 0);

                    ho.Text = "H0: Las mediciones siguen una distribucion " + dist.ToString() + " para un nivel de significacion de: " + alfa.Value.ToString();
                    ha.Text = "HA: Las mediciones NO siguen una distribucion " + dist.ToString() + " para un nivel de significacion de: " + alfa.Value.ToString();

                    if (!bondad_de_ajuste)
                        respuesta.Text = "Respuesta: No existe evidencia suficiente para rechazar H0, o sea, rechazar que las mediciones siguen una distribucion " + dist.ToString() + " para un nivel de significacion de: " + alfa.Value.ToString();
                    else
                        respuesta.Text = "Respuesta: Se reachaza H0, por lo que se acepta HA con una distribucion " + dist.ToString() + " para un nivel de significacion de: " + alfa.Value.ToString();
                }
            }

            
        }

        private double Poisson(int variable, double l)
        {
            return Math.Pow(Math.E, -l) * Math.Pow(l, variable)/Factorial(variable);
        }

        private int Factorial(int n)
        {
            if (n == 0)
                return 1;
            return Factorial(n - 1);
        }

        private double ProbabiblidadDeIntevalo(int min, int max, double l)
        {
            var retorno = 0.0;
            while (min <= max)
            {
                retorno += Poisson(min, l);
                min++;
            }
            return retorno * l;
        }

        private double Shi_Cuadrado(int[] fo, double[] fe)
        {
            var shi_cuadrado = 0.0;
            var correccion = 0.0;
            if (fo.Length <= 4) correccion = 0.5;
            for (int i = 0; i < fo.Length; i++)
            {
                shi_cuadrado += Math.Pow((fo[i] - fe[i]) - correccion, 2) / fe[i];
            }
            return shi_cuadrado;
        }

        public bool Region_Critica(double shi_cuadrado, double var_alfa, int k, int r)
        {
            return shi_cuadrado > ChiSquareTable.GetPercentil((1 - var_alfa), k - 1);
        }



    }
}
