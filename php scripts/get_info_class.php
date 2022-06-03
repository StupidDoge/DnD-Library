<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_classes'); 

$className = $_POST["className"];

$content = "SELECT * FROM `class` WHERE class.class_name = '$className'";
$result = mysqli_query($connection, $content);

if ($result) {
	if ($row = mysqli_fetch_assoc($result)) {
		echo "Источник информации: " . $row["source"] . "&;" . $row["quote"] . " " . $row["author"] . "&;Описание:&;" . $row["description"] . "&;" . $row["description_header_1"] . "&;" . $row["description_text_1"] . "&;" . $row["description_header_2"] . "&;" . $row["description_text_2"] . "&;" . $row["creation"] . "&;" . $row["fast_creation"] . "&;" . $row["multiclassing"] . "&;" . $row["class_skills"] . "&;" . $row["hit_dice"] . "&;" . $row["hits_on_1_lvl"] . "&;" . $row["hits_on_next_lvls"] . "&;" . $row["armor"] .  "&;" . $row["weapon"] . "&;" . $row["tools"] . "&;" . $row["saving_throws"] . "&;" . $row["skills"] . "&;" . $row["equipment"] . "&;" . $row["equipment_1"] . "&;" . $row["equipment_2"] . "&;" . $row["equipment_3"] . "&;" . $row["equipment_4"] . "&;" . $row["equipment_defolt"] . "&;" . $row["spellcasting"] . "&;" . $row["cantrips"] .  "&;" . $row["spell_slots"] . "&;" . $row["basic_characteristic_for_spell"] . "&;" . $row["archetype"] . "&;" . $row["archetupe_description"];
	}
} else {
	echo ("Error! Cannot show races");
}

?>