<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_races'); 

$subraceName = $_POST["subraceName"];

$content = "SELECT * FROM `subrace` WHERE subrace.subrace_name = '$subraceName'";
$result = mysqli_query($connection, $content);

if ($result) {
	if ($row = mysqli_fetch_assoc($result)) {
		echo "Раса: ". $row["race"] . "&;Описание: " . $row["description"] . "&;" . $row["names"] . "&;" . $row["characteristic_increase"] . "&;" . $row["alignment"] . "&;Особенности расы:&;" . $row["race_features"] . "&;" . $row["age"] . "&;" . $row["size"] . "&;" . $row["speed"] . "&;" . $row["language"];
	}
} else {
	echo ("Error! Cannot show subraces");
}

?>