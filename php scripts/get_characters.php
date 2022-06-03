<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_characters'); 

$content = "SELECT * FROM `character` ORDER BY id";
$result = mysqli_query($connection, $content);

if ($result) {
	while ($row = mysqli_fetch_assoc($result)) {
		echo $row["id"] . ";" . $row["name"] . ";" . $row["class_level"] . ";" . $row["race"] . ";" . $row["background"] . ";" . $row["alignment"] . ";" . $row["player_name"] . "*";
	}
} else {
	echo ("Error! Cannot show characters");
}

?>