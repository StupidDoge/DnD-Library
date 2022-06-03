<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_races'); 

$dragonType = $_POST["dragonType"];

$content = "SELECT * FROM `dragons_types` WHERE dragons_types.dragon = '$dragonType'";
$result = mysqli_query($connection, $content);

if ($result) {
	if ($row = mysqli_fetch_assoc($result)) {
		echo "Тип наносимого урона: ". $row["damage"] . "&;Оружие дыхания: " . $row["breath_weapon"];
	}
} else {
	echo ("Error! Cannot show dragons");
}

?>