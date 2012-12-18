# 
# tblCard data to tblTM and tblPerson
#
#   DATA FORMAT
#
#   1 NULL 02A004D7000000BE 87 890
#   2 NULL 02EDC9E200000086 098 00
#   8 NULL 01545E1E000D0A22 unknown NULL

sub main ()
{
    my @lines;
    while(<>)
    {
        push(@lines, $_);
        chomp();
#        print $_;
#        print "\n";

    }
    # print  "\n";

    foreach( @lines )
    {
        # 8	NULL	01545E1E000D0A22	unknown	NULL
        if(/^(.+)\t(.+)\t(.+)\t(.+)\t(.+)/i)
        {
            #print "ssssssssssr\n";
            #print "$3 $4 $5\n";
            #print ;
            #print "\n";
            my $sn          = $3;
            my $personName  = $4;
            my $remark      = $5;
            if ( $remark == "NULL" )
            {
                $remark = "";
            }
            my $s = "
declare \@sn            as nvarchar(400)
declare \@tmid          as int
declare \@personName    as nvarchar(400)
declare \@remark        as nvarchar(400)

set \@sn                = '$sn'
set \@personName        = '$personName'
set \@remark            = '$remark'

select \@tmid = tmid from tblTM where tmsn = \@sn


if \@tmid is null  
    begin
        insert into tblTm(tmsn, tmremark) values (\@sn, \@remark)
        select \@tmid = tmid from tblTM where tmsn = \@sn
    end

insert into tblPerson(personName, tmID) values (\@personName, \@tmid)
go
------------------------------------------------------------------------
            ";

            print $s;
            print "\n";
        }
    }
}

main;
