<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_races'); 

$lineageName = $_POST["lineageName"];

$content = "SELECT * FROM `lineage` WHERE lineage.lineage_name = '$lineageName'";
$result = mysqli_query($connection, $content);

if ($result) {
	if ($row = mysqli_fetch_assoc($result)) {
		echo "Источник информации: ". $row["source"] . "&;Описание: " . $row["description_1"] . "&;" . $row["description_2"] . "&;" . $row["lineage"] . "&;" . $row["kind_of_creature"] . "&;Особенности:&;" . $row["features"] . "&;" . $row["individual_features"] . "&;" . $row["characteristic_increase"] . "&;" . $row["size"] . "&;" . $row["speed"] . "&;" . $row["language"];
	}
} else {
	echo ("Error! Cannot show lineages");
}

?>