<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_races'); 

$raceName = $_POST["raceName"];

$content = "SELECT * FROM `race` WHERE race.race_name = '$raceName'";
$result = mysqli_query($connection, $content);

if ($result) {
	if ($row = mysqli_fetch_assoc($result)) {
		echo "Источник информации: " . $row["source"] . "&;" . $row["quote"] . " " . $row["author"] . "&;Описание:&;" . $row["description"]  . "&;" . $row["names"] . "&;" . $row["age"] . "&;" . "&;" . $row["size"] . "&;" . $row["alignment"] . "&;" . $row["subraces"] . "&;" . $row["background"] . "&;Особенности расы:&;" . $row["features"] . "&;" . $row["race_features"] .  "&;" . $row["language"] . "&;&;Рост характеристик:&;" . $row["characteristic_increase"] . "&;&;Скорость:&;" . $row["speed"];
	}
} else {
	echo ("Error! Cannot show races");
}

?>