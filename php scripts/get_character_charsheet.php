<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_characters'); 

$id = $_POST["id"];

$content = "SELECT * FROM `character`, `about_character`, `characteristics` WHERE character.id = '$id' AND about_character.id = '$id' AND characteristics.id = '$id'";
$result = mysqli_query($connection, $content);

if ($result) {
	if ($row = mysqli_fetch_assoc($result)) {
		echo $row["name"] . ";" . $row["class_level"] . ";" . $row["race"] . ";" . $row["background"] . ";" . $row["alignment"] . ";" . $row["player_name"] . ";" . $row["personality_traits"] . ";" . $row["ideals"] . ";" . $row["bounds"] . ";" . $row["flaws"] . ";" . $row["attacks_spellcasting"] . ";" . $row["other_proficiencies_languages"] . ";" . $row["equipment"] . ";" . $row["allies"] . ";" . $row["strength"] . ";" . $row["dexterity"] . ";" . $row["intelligence"] . ";" . $row["constitution"] . ";" . $row["wisdom"] . ";" . $row["charisma"] . ";" . $row["inspiration"] . ";" . $row["proficiency_bonus"] . ";" . $row["armor_class"] . ";" . $row["initiative"] . ";" . $row["speed"] . ";" . $row["current_hit_points"];
	}
} else {
	echo ("Error! Cannot show characters");
}

?>