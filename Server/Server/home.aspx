<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Server.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <script type="text/javascript" src="Static/visjs/vis.js"></script>
    <link href="Static/visjs/vis.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        #mynetwork {
            width: 1500px;
            height: 800px;
            border: 1px solid lightgray;
            background-color: black
        }
        #infomessage {
            font-family: Arial;
            font-weight:bold
        }
        #buttons {
            width: 119px;
        }
        #stabilisationBox {
            width: 175px;
        }
    </style>
</head>
<body>

<div id="infomessage">
<p>If you see an empty rectangle the cluster ist currently loading.<br />
Please be patient and don't refresh the page.</p>
</div>
    <div id="buttons">
        <input id="buttonCluster" type="button" value="Open/Close Clusters" onclick="clusterByHubsize()"/> 
    </div>
    <div id="stabilisationBox">
        Stabilize when clustering:<input type="checkbox" id="stabilizeCheckbox">
    </div>

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
    var clusterIndex = 0;
    var clusters = [];
    var options = {};

    // initialize your network!
    var network = new vis.Network(container, data, options);
    network.on("selectNode", function(params) {
        if (params.nodes.length == 1) {
            if (network.isCluster(params.nodes[0]) == true) {
                network.openCluster(params.nodes[0]);
            }
        }
    });
    function clusterByHubsize() {
        if (clusterIndex == 0) {
            network.setData(data);
            var clusterOptionsByData = {
                processProperties: function (clusterOptions, childNodes) {
                    clusterIndex = clusterIndex + 1;
                    clusterOptions.label = "[" + childNodes.length + "]";
                    clusterOptions.id = 'cluster:' + clusterIndex;
                    clusters.push({ id: 'cluster:' + clusterIndex });
                    return clusterOptions;
                },
                clusterNodeProperties: { borderWidth: 3, shape: 'box', font: { size: 50 } }
            };
            network.clusterByHubsize(undefined, clusterOptionsByData);
        }
        else {
            openClusters();
        }
    };
    clusterByHubsize();

    function openClusters() {
        var newClusters = [];
        for (var i = 0; i < clusters.length; i++) {
                network.openCluster(clusters[i].id);
        }
        if (document.getElementById('stabilizeCheckbox').checked === true) {
            network.stabilize();
        }
        clusterIndex = 0;
        clusters = newClusters;
    };

</script>
</body>
</html>
