Graphs
======

Simple Graphs Library for C# Applications

This library was build for the subject "Game Programming" of the Games Master on the Hamburg University of Applied Sciences.

<h2>Overview</h2>

This library contains basic datastructures that represent unweighted, non-directional Graphs with Edges and Vertices.
Additionally it provides some methods to process Graphs in certain ways, like a path search algorithm or algorithms
to determine the completeness or connectivity of a Graph.

Vertices are identified through strings and Edges are spanned over two Vertices.

<h2>Classes</h2>

<h3>Graph</h3>

The Graph class provides the basic data structure and is the core of the library.

<h5>Constructor</h5>
You can create a Graph by using either Arrays of Vertices and Edges or Arrays of strings as identifier for the Vertices and Pairs of strings to define the Edges. 
When Edges contain non-existent Vertices they will be created, so most of the times you do not need to bother about providing an array of Vertices.

<h5>AddNewVertex()</h5>
Like in the Constructor you can provide a Vertex or a string as an argument. The new Vertex will be created and added to the Graph.

<h5>AddNewEdge()</h5>
Like in the Constructor you can provide either an Edge or a Pair of strings. Also the Vertices in the Edge do not have to exist. If they don't they will be created.

<h3>Edge</h3>
The Edge basically is just a Pair of two Vertices.

<h5>Constructor</h5>
To create an Edge you can either provide two Vertices or a Pair of strings.

<h3>Vertex</h3>
Vertices are identified through strings. Equality will also be determined only through the string.

<h5>Constructor</h5>
A Vertex can be created by providing a string as an identifier.

<h3>GraphHelper</h3>
The GraphHelper-Class is a static class that provides some methods that can help analysing a Graph.

<h5>FindAdjacentEdges()</h5>
Takes a Graph and a Vertex or an Edge as arguments.
Finds all Edges that contain the given Vertex or one of the Vertices in the given Edge.

<h5>FindAdjacentVertices()</h5>
Takes a Graph and a Vertex or an Edge as arguments.
Finds all Vertices that are neighbours to the given Vertex or one of the Vertices in the given Edge.

<h3>GraphProperties</h3>
The GraphProperties-Class is a static class that provides some methods to determine specific properties of a Graph. 
This Class also provides all methods as asynchronous methods.

<h5>IsVertexReachableFrom(Graph, Vertex, Vertex)</h5>
Returns true when there is a path between the two Vertices.

<h5>IsGraphComplete(Graph)</h5>
Returns true when the Graph is complete.

<h5>IsGraphBipartite(Graph)</h5>
Returns true when the Graph is bipartite.

<h5>IsGraphConnected(Graph)</h5>
Returns true when the Graph is connected.

<h3>DijkstraSearch</h3>
The DijkstraSearch-Class provides path searches.

<h5>Search(Graph, Vertex, Vertex)</h5>
Returns an array of Vertices that describe a path from one Vertex to another. The path is determined by using the Dijkstra-Search-Algorithm.

<h5>CountReachableNodes(Graph, Vertex)</h5>
Counts and returns the number of vertices that can be reached when starting from the given Vertex.

<h2>Conclusion</h2>
This library just provides some very basic methods and data structures for graphs. Maybe in the future we will add the support of directional and weighted Graphs as well. Since this is not our main project it is not very likely.
