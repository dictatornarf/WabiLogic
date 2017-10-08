<?php

function GenerateKey($name, $spice) {
	$KeyChars = array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5', '6', '8', '9');

	if (strlen($name) < 1)
		return 'ERROR1';

	if (strlen($spice) != 4)
		return 'ERROR2';

	for ($i = 0; $i < strlen($spice); $i++) {
		$char = substr($spice, $i, 1); //Get $input[i]
		if (!in_array($char, $KeyChars))
			return 'ERROR3';
	}

	$pre = '私はガラスを食べられます。それは私を傷つけません。';
	$post = 'Μπορῶ νὰ φάω σπασμένα γυαλιὰ χωρὶς νὰ πάθω τίποτα.';

	$input = strtoupper($name);
	$str = '';
	for ($i = 0; $i < strlen($input); $i++) {
		$char = substr($input, $i, 1); //Get $input[i]
		if (strlen(trim($char)) > 0) { //Check if not whitespace
			$str = $str . $char;	
		}
	}

	$md5 = strtoupper(md5($pre . $str . $post));

	$pointerValue = 0;

	$key = '';
	for ($i = 0; $i < strlen($md5); $i++) {
		$char = substr($md5, $i, 1); //Get $input[i]

		$pointerValue += ScrambleIntValue($char) + ScrambleIntValue(substr($spice, $i % strlen($spice), 1));
		$pointerValue %= count($KeyChars);

		if ($i > 0 && $i % 4 == 0)
			$key = $key . '-';

		$key = $key . $KeyChars[$pointerValue];
	}

	return $spice . '-' . $key;	
}

function ScrambleIntValue($c) {
	$KeyChars = array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5', '6', '8', '9');

	$toFind = strtoupper($c);

	for ($i = 0; $i < count($KeyChars); $i++) {
		if ($KeyChars[$i] == $toFind)
			return $i + 1;
	}

	return -1;
}

function ConfirmKey($name, $key) {
	return (GenerateKey($name, substr($key, 0, 4)) == $key);
}

?>