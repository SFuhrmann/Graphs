using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Graphs;
using System.Text.RegularExpressions;

namespace GraphsSample
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Graph graph;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CreateButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            //Disable Control to prevent this method from running parallely multiple times
            CreateButton.IsEnabled = false;

            //Reset Edges Label
            ShowGraphEdgesLabel.Content = "";

            //Create an array of edges
            Edge[] edges = await CreateEdgesArrayAsync(GraphEdgesTextBox.Text);

            if (edges.Length > 0)
            {
                //Create a graph by using an array of edges. No extra vertices need to be declared.
                graph = new Graph(new Vertex[] { }, edges);

                //Update first label according to the Completeness of the created graph
                UpdateIsGraphCompleteLabel(await GraphProperties.IsGraphCompleteAsync(graph));

                //Update second label according to the Bipartition of the created graph
                UpdateIsGraphBipartiteLabel(await GraphProperties.IsGraphBipartiteAsync(graph));

                //Update third label according to the Connectivity of the created graph
                UpdateIsGraphConnectedLabel(await GraphProperties.IsGraphConnectedAsync(graph));

                //Reset Dijkstra Path Label
                DijkstraPathLabel.Content = "";

                //Update Edges Label
                ShowGraphEdgesLabel.Content = "Current Graph: " + GraphEdgesTextBox.Text;
            }
            else
            {
                GraphEdgesTextBox.Text = "";
                GraphEdgesSampleLabel.Content = "Please use this pattern: (A,B)(A,C)(B,C)";
            }

            //Enable Controls again
            CreateButton.IsEnabled = true;
        }

        private async void SearchButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            //Disable Control to prevent this method from running parallely multiple times
            SearchButton.IsEnabled = false;

            //Create Start and Goal Vertices
            Vertex start = new Vertex(StartVertexTextBox.Text);
            Vertex goal = new Vertex(GoalVertexTextBox.Text);

            //Give feedback to the user
            DijkstraPathLabel.Content = "Searching for path from " + start + " to " + goal + " ...";

            //if the graph was not initialized yet, tell the user to create one
            if (graph == null)
                DijkstraPathLabel.Content = "Create a Graph before doing a path search.";
            //if the graph does not contain both the vertices tell the user to use other vertices
            else if (!(graph.Vertices.Contains(start) && graph.Vertices.Contains(goal)))
                DijkstraPathLabel.Content = "The Graph does not contain that start and/or goal.";
            else
            {
                //Search for the Path
                Vertex[] path = await Task.Run(() => { return DijkstraSearch.Search(graph, start, goal); });

                //Convert path to a readable string
                string sPath = ConvertVerticesToString(path);

                //Set Label Text to found path
                DijkstraPathLabel.Content = sPath;
            }

            //Enable Control again
            SearchButton.IsEnabled = true;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //***************************************************************************************************************************************************************//
        //***************************************************************************************************************************************************************//
        //***After this point there is no code regarding the Graphs.dll and is only there for the usability of this small app. Therefore you can ignore it completely.***//
        //***************************************************************************************************************************************************************//
        //***************************************************************************************************************************************************************//
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------//

        #region UpdateLabelFunctions

        private void UpdateIsGraphBipartiteLabel(bool bipartite)
        {
            if (bipartite == true)
            {
                IsGraphBipartiteLabel.Content = "Graph is bipartite.";
                IsGraphBipartiteLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
            else
            {
                IsGraphBipartiteLabel.Content = "Graph is not bipartite.";
                IsGraphBipartiteLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }

        private void UpdateIsGraphCompleteLabel(bool complete)
        {
            if (complete == true)
            {
                IsGraphCompleteLabel.Content = "Graph is complete.";
                IsGraphCompleteLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
            else
            {
                IsGraphCompleteLabel.Content = "Graph is not complete.";
                IsGraphCompleteLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }

        private void UpdateIsGraphConnectedLabel(bool connected)
        {
            if (connected == true)
            {
                IsGraphConnectedLabel.Content = "Graph is connected.";
                IsGraphConnectedLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
            else
            {
                IsGraphConnectedLabel.Content = "Graph is not connected.";
                IsGraphConnectedLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }

        #endregion

        #region HelperFunctions

        /// <summary>
        /// Reads out the Edges defined by a string.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private async Task<Edge[]> CreateEdgesArrayAsync(string e)
        {
            return await Task.Run(() =>
            {
                List<Edge> result = new List<Edge>();

                Regex r = new Regex(@"^([(]\w*[,]\w*[)])*$");

                if(!(r.IsMatch(e)))
                {
                    return result.ToArray();
                }

                e = RemoveWhitespace(e);
                string[] vertices = e.Split(new Char[] { '(', ')', ',' });
                vertices = vertices.Where(x => !String.IsNullOrEmpty(x)).ToArray();

                for (int i = 0; i < vertices.Length; i += 2)
                {
                    Vertex v1 = new Vertex(vertices[i]);
                    Vertex v2 = new Vertex(vertices[i + 1]);

                    result.Add(new Edge(v1, v2));
                }

                return result.ToArray();
            });
        }

        /// <summary>
        /// Removes all Whitespace characters from a string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        private string ConvertVerticesToString(Vertex[] path)
        {
            string result = "(";
            int i = 0;
            foreach(Vertex v in path)
            {
                result += v.ToString();
                if (i == path.Length - 1)
                    result += ")";
                else
                    result += ", ";
                i++;
            }
            return result;
        }
        #endregion

        #region Usability

        private void GraphEdgesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(GraphEdgesTextBox.Text))
                GraphEdgesSampleLabel.Content = "(A,B)(A,C)(B,C) ...";
            else
                GraphEdgesSampleLabel.Content = "";
            
        }

        private void GraphEdgesTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                CreateButton_ClickAsync(sender, new RoutedEventArgs());
        }

        #endregion
    }
}
