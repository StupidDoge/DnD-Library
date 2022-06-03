<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_classes'); 

$skillID = $_POST["skillID"];

$content = "SELECT * FROM `additional_skills` WHERE additional_skills.id = '$skillID'";
$result = mysqli_query($connection, $content);

if ($result) {
	if ($row = mysqli_fetch_assoc($result)) {
		echo $row["archetype"] . "&;" . $row["level"] . "&;" . $row["description"];
	}
} else {
	echo ("Error! Cannot show races");
}

?>