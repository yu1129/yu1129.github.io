<?
function pathconvert($cur,$absp)//當前文件，目標路徑
{
	$cur = str_replace('\\','/',$cur);
	$absp = str_replace('\\','/',$absp);
	$sabsp=explode('/',$absp);
	$scur=explode('/',$cur);
	$la=count($sabsp)-1;
	$lc=count($scur)-1;
	$l=max($la,$lb);
	
	for ($i=0;$i<=$l;$i++)
	{
		if ($sabsp[$i]!=$scur[$i])
			break;
	}
	$k=$i-1;
	$path="";
	for ($i=1;$i<=($lc-$k-1);$i++)
		$path.="../";
	for ($i=$k+1;$i<=($la-1);$i++)
		$path.=$sabsp[$i]."/";
	$path.=$sabsp[$la];
	echo $path;
}

$path=pathconvert("/php/devlog/devlog_export.php","/uploadfile/devlog/1.php");
?>