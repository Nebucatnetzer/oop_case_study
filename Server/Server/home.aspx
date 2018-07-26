<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Server.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <script type="text/javascript" src="Static/visjs/vis.js"></script>
    <link href="Static/visjs/vis.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        #mynetwork {
            width: 1500px;
            height: 900px;
            border: 1px solid lightgray;
            background-color: black
        }
    </style>
</head>
<body>
<div id="mynetwork"></div>

<script type="text/javascript">
    // create an array with nodes
    var nodes = new vis.DataSet(<%=this.nodes%>);
    // create an array with edges
    var edges = new vis.DataSet(<%=this.edges%>);

    // create a network
    var container = document.getElementById('mynetwork');

    // provide the data in the vis format
    var data = {
        nodes: nodes,
        edges: edges
    };
    var options = {};

    // initialize your network!
    var network = new vis.Network(container, data, options);
</script>
</body>
</html>
