﻿using GraphSharp.Controls;
using SEViz.Common;
using SEViz.Common.Model;
using SEViz.Integration.Model;
using SEViz.Integration.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SEViz.Integration.ViewModel
{
    public class SEGraphLayout : GraphLayout<SENode, SEEdge, SEGraph>
    {
    
    }

    public class SEGraphViewModel
    {
        #region Properties

        private SEGraph _graph;
        public SEGraph Graph
        {
            get { return _graph; }
            set { _graph = value; }
        }

        public SEData Data { get; private set; }

        #endregion

        public SEGraphViewModel()
        {
            var data = new SEData();
            
            LoadGraph(null,data);

            // Adding runs to the leaf nodes
            data.Runs.Add(Graph.Vertices.ElementAt(3),new List<SENode>() { Graph.Vertices.ElementAt(2),Graph.Vertices.ElementAt(3),Graph.Vertices.ElementAt(1),Graph.Vertices.ElementAt(0) });
        }



        public void LoadGraph(SEGraph graph, SEData data)
        {
            // TODO starting sample graph
            
            graph = new SEGraph();

            Data = data;

            for (int i = 0; i < 8; i++)
            {
                var n = new SENode(i, null, null, null, null, null, (i==4 || i==1) ? true : false);
                graph.AddVertex(n);
            }

            graph.AddEdge(new SEEdge(0, graph.Vertices.ElementAt(0), graph.Vertices.ElementAt(1)));
            graph.AddEdge(new SEEdge(1, graph.Vertices.ElementAt(1), graph.Vertices.ElementAt(2)));
            graph.AddEdge(new SEEdge(2, graph.Vertices.ElementAt(2), graph.Vertices.ElementAt(3)));
            graph.AddEdge(new SEEdge(3, graph.Vertices.ElementAt(2), graph.Vertices.ElementAt(4)));
            graph.AddEdge(new SEEdge(4, graph.Vertices.ElementAt(0), graph.Vertices.ElementAt(5)));
            graph.AddEdge(new SEEdge(5, graph.Vertices.ElementAt(1), graph.Vertices.ElementAt(7)));
            graph.AddEdge(new SEEdge(6, graph.Vertices.ElementAt(4), graph.Vertices.ElementAt(6)));
            // TODO ending sample graph
            
            Graph = graph;
           
            //Graph = SEGraph.Deserialize(@"D:\graph.graphml");
        }
    }
}
