#!/usr/bin/perl -w
use strict;

my $deviceID = 73;
my $tmID = 10;
my @days = (1 ... 31);
my @hours =(0 ... 23);
my @minutes = (0, 30);

foreach my $day(@days)
{
    foreach my $hour(@hours)
    {
        foreach my $min(@minutes)
        {
            my $tmdataDT="2012-12-$day $hour:$min:00";
    
            my $sql= "insert into tblTmData(deviceid, tmid, tmdatadt) values($deviceID, $tmID,'$tmdataDT')";
            print "$sql\n";
        }
    }
}


