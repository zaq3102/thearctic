package com.ssafy.thearctic.common.model.response.util;

import java.net.InetAddress;
import java.net.UnknownHostException;

public class GetIp {
    public static String getServerIp() {
        InetAddress local = null;
        try {
            local = InetAddress.getLocalHost();
        }
        catch (UnknownHostException e ) {
            e.printStackTrace();
        }

        if( local == null ) {
            return null;
        }
        else {
            return local.getHostAddress();
        }
    }
}
