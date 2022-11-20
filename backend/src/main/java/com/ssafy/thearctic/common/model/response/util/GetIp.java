package com.ssafy.thearctic.common.model.response.util;

import javax.servlet.http.HttpServletRequest;
import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.SocketException;
import java.net.UnknownHostException;

public class GetIp {
//    public static String getServerIp() {
//        InetAddress local = null;
//        try {
//            local = InetAddress.getLocalHost();
//        }
//        catch (UnknownHostException e ) {
//            e.printStackTrace();
//        }
//
//        if( local == null ) {
//            return null;
//        }
//        else {
//            return local.getHostAddress();
//        }
//    }

    public static String getClientIp(HttpServletRequest request) {
        String result = null;

        result = request.getHeader("X-Forwarded-For");

        if (result == null || result.length() == 0 || "unknown".equalsIgnoreCase(result)) {
            result = request.getHeader("Proxy-Client-IP");
        }
        if (result == null || result.length() == 0 || "unknown".equalsIgnoreCase(result)) {
            result = request.getHeader("WL-Proxy-Client-IP");
        }
        if (result == null || result.length() == 0 || "unknown".equalsIgnoreCase(result)) {
            result = request.getHeader("HTTP_CLIENT_IP");
        }
        if (result == null || result.length() == 0 || "unknown".equalsIgnoreCase(result)) {
            result = request.getHeader("HTTP_X_FORWARDED_FOR");
        }
        if (result == null || result.length() == 0 || "unknown".equalsIgnoreCase(result)) {
            result = request.getRemoteAddr();
        }

        return result==null?"":result;
    }

    public static String getLocalMacAddress() {
        String mac = null;

        try {
            InetAddress addr = InetAddress.getLocalHost();
            NetworkInterface ni = NetworkInterface.getByInetAddress(addr);

            mac = ni.getHardwareAddress().toString();
        }
        catch (SocketException | UnknownHostException e ) {
            e.printStackTrace();
        }

        return mac;
    }
}
