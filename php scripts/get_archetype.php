<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_classes'); 

$archetypeName = $_POST["archetypeName"];

$content = "SELECT * FROM `archetype` WHERE archetype.archetype_name = '$archetypeName'";
$result = mysqli_query($connection, $content);

if ($result) {
	if ($row = mysqli_fetch_assoc($result)) {
		echo "Источник информации: " . $row["source"] . "&;" . $row["class"] . "&;" . $row["quote"] . " " . $row["author"] . "&;Описание:&;" . $row["description"];
	}
} else {
	echo ("Error! Cannot show races");
}

?>