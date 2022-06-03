<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_characters');

if ($connection->connect_error)
	exit ('1');

$id = $_POST["id"];

$characterName = $_POST["name"];
$classLevel = $_POST["class_level"];
$race = $_POST["race"];
$background = $_POST["backstory"];
$alignment = $_POST["outlook"];
$playerName = $_POST["player_name"];

$traits = $_POST["traits"];
$ideals = $_POST["ideals"];
$bounds = $_POST["affections"];
$flaws = $_POST["weaknesses"];
$attacks = $_POST["attacks"];
$equipment = $_POST["equipment"];
$allies = $_POST["allies"];
$languages = $_POST["languages"];

$strength = intval($_POST["strength"]);
$dexterity = intval($_POST["dexterity"]);
$constitution = intval($_POST["constitution"]);
$intelligence = intval($_POST["intelligence"]);
$wisdom = intval($_POST["wisdom"]);
$charisma = intval($_POST["charisma"]);
$inspiration = intval($_POST["inspiration"]);
$proficiencyBonus = intval($_POST["proficiency_bonus"]);
$armorClass = intval($_POST["armor_class"]);
$initiative = intval($_POST["initiative"]);
$speed = intval($_POST["speed"]);
$hitPoints = intval($_POST["hit_points"]);

$insertCharacteristics = "INSERT INTO `characteristics` (strength, dexterity, constitution, intelligence, wisdom, charisma, inspiration, proficiency_bonus, armor_class, initiative, speed, current_hit_points) VALUES ('$strength', '$dexterity', '$constitution', '$intelligence', '$wisdom', '$charisma', '$inspiration', '$proficiencyBonus', '$armorClass', '$initiative', '$speed', '$hitPoints')";

$updateCharacter = "UPDATE `character` SET name = '$characterName', class_level = '$classLevel', race = '$race', background = '$background', alignment = '$alignment', player_name = '$playerName' WHERE id = '$id'";
$updateAboutCharacter = "UPDATE `about_character` SET personality_traits = '$traits', ideals = '$ideals', bounds = '$bounds', flaws = '$flaws', attacks_spellcasting = '$attacks', equipment = '$equipment', allies = '$allies', other_proficiencies_languages = '$languages' WHERE id = '$id'";
$updateCharacteristics = "UPDATE `characteristics` SET strength = '$strength', dexterity = '$dexterity', constitution = '$constitution', intelligence = '$intelligence', wisdom = '$wisdom', charisma = '$charisma', inspiration = '$inspiration', proficiency_bonus = '$proficiencyBonus', armor_class = '$armorClass', initiative = '$initiative', speed = '$speed', current_hit_points = '$hitPoints' WHERE id = '$id'";

mysqli_query($connection, $updateCharacter) or die("2: update character failed");
mysqli_query($connection, $updateAboutCharacter) or die("3: update about character failed");
mysqli_query($connection, $updateCharacteristics) or die("4: update characteristics failed");

echo "0";

?>