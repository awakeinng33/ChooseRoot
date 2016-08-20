using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChooseRootProj
{
    public partial class Form1 : Form
    {

        Graph graph_obj;
        int size;
        public Form1()
        {
            InitializeComponent();
            graph_obj = new Graph();
        }

        private void SizeMatrixConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                size = Convert.ToInt32(sizeMatrixText.Text);
                MatrixGrid.ColumnCount = size;
                MatrixGrid.RowCount = size;
                fillCellsLabel.Enabled = true;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void BuildMatrix(object sender, EventArgs e)
        {
            List<List<int>> matrix = new List<List<int>>();

            try
            {
                for (int i = 0; i < MatrixGrid.Rows.Count; i++)
                {
                    List<int> row = new List<int>();

                    for (int j = 0; j < MatrixGrid.Columns.Count; j++)
                    {
                        if (MatrixGrid[i, j].Value == null) throw new Exception("You haven't filled all the cells! ");
                        row.Add(Convert.ToInt32(MatrixGrid[i, j].Value));
                        if (j == (MatrixGrid.Columns.Count - 1))
                            matrix.Add(row);

                    }
                }

                graph_obj.SearchRootMethodClipping(matrix);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MatrixGrid.Rows.Count; i++)
            {

                for (int j = 0; j < MatrixGrid.Columns.Count; j++)
                {
                    MatrixGrid[i, j].Value = null;
                }
            }
        }

        private void BuildFromFile_Click(object sender, EventArgs e)
        {

            Stream myStream = null;
            StreamReader sr;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {

                        sr = new StreamReader(openFileDialog.FileName, Encoding.Default);
                      
                        string s = sr.ReadToEnd();
                        sr.Close();
                        string [] row = s.Split('\n');
                        for (int i = 0; i < size; i++)
                        {
                           
                            for (int j = 0; j < size; j++)
                            {
                                MatrixGrid[i, j].Value = row[i].Split(' ')[j];

                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
        }

        public class Graph
        {
            public void SearchRootMethodClipping(List<List<int>> current_matrix)
            {

                List<List<int>> matrix_dyn = new List<List<int>>();
                List<int> del_col = new List<int>();

                int size_del = 0;
                int[] static_del_array = new int[current_matrix.Count];

                List<int> numOfVer = new List<int>();
                List<int> sumOfRow = new List<int>();

                bool flag = false;
                bool isNumOfVerAdd = false;
                bool isDelNumOfVer = false;
                bool isDelSumOfRow = false;

                int sum_row = 0;

              
                try
                {
                    while (!flag)
                    {
                        if (current_matrix.Count <= 2) { flag = true; EndOfSearch(numOfVer, sumOfRow); }

                        for (int i = 0; i < current_matrix.Count; i++)
                        {
                            if (!isNumOfVerAdd)
                                numOfVer.Add(i + 1);

                            List<int> row = new List<int>();
                            for (int j = 0; j < current_matrix.Count; j++)
                            {
                                sum_row += current_matrix[i][j];
                                row.Add(current_matrix[i][j]);
                                if (j == (current_matrix.Count - 1))
                                {
                                    if (sum_row > 1) matrix_dyn.Add(row);

                                    else del_col.Add(i);

                                    if (!isDelSumOfRow)
                                        sumOfRow.Add(sum_row);

                                    sum_row = 0;
                                }

                            }
                        }

                        for (int k = 0; k < del_col.Count; k++)
                        {
                            static_del_array[k] = del_col[k];
                        }
                        size_del = del_col.Count;

                        for (int k = 0; k < matrix_dyn.Count; k++)
                        {
                            for (int i = 0; i < del_col.Count;)
                            {

                                matrix_dyn[k].RemoveAt(del_col[i]);
                                if (!isDelNumOfVer)
                                {
                                    sumOfRow.RemoveAt(del_col[i]);
                                    numOfVer.RemoveAt(del_col[i]);

                                }
                                del_col.RemoveAt(0);

                                for (int m = 0; m < del_col.Count; m++)
                                    del_col[m] -= 1;

                            }

                            isDelNumOfVer = true;
                            for (int n = 0; n < size_del; n++)
                            {
                                del_col.Add(static_del_array[n]);
                            }
                        }


                        del_col.RemoveRange(0, del_col.Count);

                        current_matrix.RemoveRange(0, current_matrix.Count);
                        for (int k = 0; k < matrix_dyn.Count; k++)
                        {
                            List<int> row = new List<int>();

                            for (int i = 0; i < matrix_dyn.Count; i++)
                            {

                                row.Add(matrix_dyn[k][i]);
                                if (i == (matrix_dyn.Count - 1)) current_matrix.Add(row);

                            }
                        }

                        matrix_dyn.RemoveRange(0, matrix_dyn.Count);
                        isNumOfVerAdd = true;
                        isDelSumOfRow = true;
                        isDelNumOfVer = false;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }


            public void SearchHeightMethod(List<List<int>> current_matrix)
            {
                List<int> sumOfRow = new List<int>();
                int sum_row = 0;
                Dictionary<string, int[]> heightOfVer = new Dictionary<string, int[]>();
                List<string> alreadyChecked = new List<string>();

                int[] currentHeightRow = new int[current_matrix.Count];

                List<string> needChecked = new List<string>();

                int[,] currentHeight = new int[current_matrix.Count, current_matrix.Count];
                bool firstIteration = false;
                bool needReturnInBranch = false;
                bool delSmtFromNeedChecked = false;
                int numb = 0;
                int col = 0;
                int curRowMatrix = 0;

                int coincidence = 0;

                for (int i = 0; i < current_matrix.Count; i++)
                {

                    List<int> row = new List<int>();
                    for (int j = 0; j < current_matrix.Count; j++)
                    {
                        sum_row += current_matrix[i][j];
                        currentHeight[i,j] = 0;
                    }
                    sumOfRow.Add(sum_row);
                    sum_row = 0;
                    currentHeightRow[i] = 0;
                }
                for (int k = 1; k < current_matrix.Count; k++)
                {
                    firstIteration = true;
                    curRowMatrix = k;

                    for (; curRowMatrix < current_matrix.Count; curRowMatrix++)
                    {
                        if ((sumOfRow[curRowMatrix] == 1) && (!firstIteration))
                        {
                            string[] ci = needChecked[0].Split(':');
                            curRowMatrix = Convert.ToInt32(ci[0]) - 1;
                            col = Convert.ToInt32(ci[1]) - 1;
                            needChecked.RemoveAt(1);
                            needChecked.RemoveAt(0);
                            delSmtFromNeedChecked = true;
                            numb++;
                        }

                        if ((sumOfRow[curRowMatrix] > 2)||(sumOfRow[curRowMatrix] == 2)&&(firstIteration)) needReturnInBranch = true;     
                        for (; col < current_matrix.Count; col++)
                        {
                            if ((current_matrix[curRowMatrix][col] != 0) && (!alreadyChecked.Contains("" + (curRowMatrix + 1) + ":" + (col + 1))))
                            {


                                currentHeight[k, numb]++;

                                alreadyChecked.Add("" +(curRowMatrix + 1) + ":" + (col + 1));
                                alreadyChecked.Add("" + (col + 1) + ":" + (curRowMatrix + 1));

                                if (heightOfVer.ContainsKey("x" + (k + 1)))
                                {
                                    for (int p = 0; p < current_matrix.Count; p++) currentHeightRow[p] = currentHeight[k, p];
                                    heightOfVer.Remove("x" + (k + 1));
                                    heightOfVer.Add("x" + (k + 1), currentHeightRow);
                                }
                                else heightOfVer.Add("x" + (k + 1), currentHeightRow);

                                int old_i = curRowMatrix;
                                curRowMatrix = col - 1;
                                if (needReturnInBranch)
                                {

                                    for (col = col + 1; col < current_matrix.Count; col++)
                                    {
                                        if (current_matrix[old_i][col] != 0)
                                        {
                                            int temp = currentHeight[k, numb];
                                            coincidence++;
                                            needChecked.Add(("" + (old_i + 1) + ":" + (col + 1)));
                                            needChecked.Add(("" + (col + 1) + ":" + (old_i + 1)));
                                            currentHeight[k, numb + coincidence] = temp - 1;
                                        }
                                    }
                                    coincidence = 0;
                                    needReturnInBranch = false;
                                }

                                break;
                            }
                        }
                        firstIteration = false;
                        col = 0;
                    }

                    alreadyChecked.RemoveRange(0, alreadyChecked.Count);
                    col = 0;
                    numb = 0;
                }


                for (int v = 1; v < 7; v++)
                    for (int x = 1; x < 7; x++)
                        MessageBox.Show("x" +x + ":" +currentHeight[v,x].ToString());

            }

            public void EndOfSearch(List<int> numOfVer, List<int> sumOfRow)
            {
                if (numOfVer.Count == 2)
                {
                    if (sumOfRow[0] <= sumOfRow[1]) MessageBox.Show("Root: " + numOfVer[0].ToString());
                    else MessageBox.Show("Root: " + numOfVer[1].ToString());
                }

                if (numOfVer.Count == 1) MessageBox.Show("Root: " + numOfVer[0].ToString());
            }
        }
    }
}