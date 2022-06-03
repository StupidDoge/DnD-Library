<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_classes'); 

$tableName = $_GET["tableName"];

switch ($tableName) {
	case "class":
		$content = "SELECT * FROM `class` ORDER BY class_name";
		$result = mysqli_query($connection, $content);

		if ($result)
			while ($row = mysqli_fetch_assoc($result))
				echo $row["class_name"] . ";";
		else
			echo ("Error! Cannot show class");
		break;

	case "archetype":
		$content = "SELECT * FROM `archetype` ORDER BY archetype_name";
		$result = mysqli_query($connection, $content);

		if ($result)
			while ($row = mysqli_fetch_assoc($result))
				echo $row["archetype_name"] . ";";
		else
			echo ("Error! Cannot show archetype");
		break;

	case "additional_skills":
		$content = "SELECT * FROM `additional_skills` ORDER BY add_skill_name";
		$result = mysqli_query($connection, $content);

		if ($result)
			while ($row = mysqli_fetch_assoc($result))
				echo $row ["id"] . "&" . $row["add_skill_name"] . ";";
		else
			echo ("Error! Cannot show additional_skills");
		break;

	case "class_skills":
		$content = "SELECT * FROM `class_skills` ORDER BY skill_name";
		$result = mysqli_query($connection, $content);

		if ($result)
			while ($row = mysqli_fetch_assoc($result))
				echo $row ["id"] . "&" . $row["skill_name"] . ";";
		else
			echo ("Error! Cannot show class_skills");
		break;
}
?>