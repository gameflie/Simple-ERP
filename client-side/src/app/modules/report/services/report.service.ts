import { Injectable } from '@angular/core';
import { DatePipe } from '@angular/common';

@Injectable()

export class ReportService {
  constructor(private datePipe: DatePipe) { }


  public generateReport(title: any, reportData: any, paidUpTotal: number, balanceTotal: number) {

    let popupWin;
    // printContents = document.getElementById('print-section').innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    popupWin.document.open();
    var html = `
      <html dir="rtl">
        <head>
          <title>`+ title + `</title>
          <style>
          table { 
            width: 98%; 
            border-collapse: collapse; 
            margin:50px auto;
            margin-top: -9px;
            overflow-x:auto;
            margin-bottom: 0px;
            }
          
          /* Zebra striping */
          tr:nth-of-type(odd) { 
            background: #eee; 
            }
          
          th { 
            background: #bec5c5; 
            color: black; 
            font-weight: bold; 
            }
          
          td, th { 
            padding: 10px; 
            border: 1px solid #ccc; 
            text-align: left; 
            font-size: 18px;
            }
          
          </style>

          <meta charset="utf-8">
          <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
          <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
          <!-- VENDOR CSS -->
          <link rel="stylesheet" href="src/assets/vendor/bootstrap/css/bootstrap.min.css">
          <link rel="stylesheet" href="src/assets/vendor/font-awesome/css/font-awesome.min.css">
          <link rel="stylesheet" href="src/assets/vendor/linearicons/style.css">
          <link rel="stylesheet" href="src/assets/vendor/chartist/css/chartist-custom.css">
          <!-- MAIN CSS -->
          <link rel="stylesheet" href="src/assets/css/main.css">
          <!-- FOR DEMO PURPOSES ONLY. You should remove this in your project -->
          <link rel="stylesheet" href="src/assets/css/demo.css">
          <!-- GOOGLE FONTS -->
          <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700" rel="stylesheet">
          <!-- ICONS -->
          <link rel="apple-touch-icon" sizes="76x76" href="src/assets/img/apple-icon.png">
          <link rel="icon" type="image/png" sizes="96x96" href="src/assets/img/favicon.png">

        </head>
        <body onload="window.print()">
          <div class="wrapper" style="font-family: 'Helvetica Neue', lato, arial, sans-serif;font-size: 12px;">
            <table class="main-table" style="width: 100%;table-layout: fixed;">
              <tr>
                <td></td>
                <td width="1000">
                  <div class="header" style="text-align: center;margin: 10px 0 10px 0;">
                    <img src="http://localhost:54095/Images/report-header.png" width="200" height="130">
                  </div>
                  <div class="report" style="margin-bottom: 50px;">
                  <table class="table table-bordered">
                    <thead>
                      <tr>`
    html += `<th stye="background: #bec5c5;color: black;ont-weight: bold; ">اجمالي المدفوعات </th>`;
    html += `<th >اجمالي الرصيد</th>`;
    html += `<th >الاجمالي </th>`;
    html += `</tr>
                    </thead>
                    <tbody>`;
    html += `<tr>
                          <td>`+ paidUpTotal.toFixed(2) + `</td>
                          <td >`+  balanceTotal.toFixed(2) + `</td>
                          <td >`+(paidUpTotal - balanceTotal).toFixed(2) + `</td>
                        </tr>`;
    html += `</tbody>`;
    html += `</table>`;
    for (let data of reportData) {
      html += `<h2 style="font-weight: 300;margin-left: 100%;">` + data.title + ` </h2>
                      <table class="table table-bordered">
                        <thead>
                          <tr>`
      for (let header of data.headers) {
        html += `<th stye="background: #bec5c5;color: black;font-weight: bold;">` + header + `</th>`;
      }
      html += `</tr>
                        </thead>
                        <tbody>`;
      for (let row of data.list) {
        html += `<tr>`;
        for (let property of data.properties) {
          html += `<td >`;
          if (property.includes('Date')) {
            html += this.datePipe.transform(row[property], 'yyyy/MM/dd')
          }
          else {
            html += row[property]
          }

          + `</td>`;
        }
        html += `</tr>`;
      }
      html += `</tbody>`;
      html += `</table>`;
    }
    html += `</td>
                <td></td>
              </tr>
            </table>
          </div>
        </body>
      </html>`
    popupWin.document.write(html);
    popupWin.document.close();
  }

}