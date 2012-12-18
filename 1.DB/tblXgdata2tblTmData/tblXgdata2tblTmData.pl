
# 
#
#   
#

sub main ()
{
    my @lines;
    while(<>)
    {
        push(@lines, $_);
        chomp();
    }

    foreach( @lines )
    {
        # deviceid \t sn \t dt
        #
        # 73	01545E1E000D0A22	2012-12-10 15:54:31.000
        if(/^(.+)\t(.+)\t(.+)/i)
        {
            my $deviceid    = $1;
            my $sn          = $2;
            my $dt          = $3;

            my $s = "
declare \@tmid int
select \@tmid = tmid from tblTM where tmsn = '$sn'
insert into tblTMData(deviceid, tmid, tmdatadt) values ($deviceid, \@tmid, '$dt')
go
------------------------------------------------------------------------
            ";

            print $s;
            print "\n";
        }
    }
}

main;

