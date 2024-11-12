<template>
  <div>

    <!-- 工具区域 -->
    <div ref="chartRef" :class="className" :style="{height:height,width:width}" />
  </div>
</template>
<script setup name="monthlysaleschatbar">
  import * as echarts from 'echarts'

  import {
    getListMonthlySalesBar
  }
    from '@/api/statistics/sales.js'
  const { proxy } = getCurrentInstance()
  const animationDuration = 3000

  let className = 'chart';
  let width = '100%';
  let height = '400px';
  let MapList = [];
  let rows = [];
  let BarList = [];
  let salesQty = [];
  let salesAmount = [];
  let salesDate = [];
  let chart = null;
  let queryParams = {
    salesQty: undefined,
    salesAmount: undefined,
    salesDate: undefined,
  };

  const getBarList = () => {

    getListMonthlySalesBar(queryParams).then(response => {
      MapList = response.data;
      //console.log("柱状图数据：" + MapList);         // 确认数据有获取到
      let obj = eval(MapList);
      for (let i = 0; i < obj.length; i++) {
        salesQty.push(MapList[i].salesQty);
        salesAmount.push(MapList[i].salesAmount);
        salesDate.push(MapList[i].salesDate);
      }
      //动态插入数据时，数据在这里设置更新
      chart.setOption({
        xAxis: {
          data: salesDate
        },
        series: [{
          name: '台数',
          data: salesQty,
        },
        {
          name: '金额',
          data: salesAmount,
        }]
      });
    });
  };
  // 定义自定义主题颜色中国传统24节气色谱：
  //黄白游,松花,缃叶,苍黄,盈盈,水红,苏梅,紫茎屏风,
  // 赤缇,朱草,苏梅,顺圣,皦玉,吉量,韶粉,顺圣,紫蒲,
  // 赪紫,齐紫,凝夜紫,昌容,紫薄汗,茈藐,紫紶,青粲,
  // 翠缥,人籁,水龙吟,彤管,渥赭,唇脂,朱孔阳,
  // 筠雾,瓷秘,琬琰,青圭,赩炽,石榴裙,朱湛,大繎,
  // 骍刚,赪霞,赪尾,朱柿,夕岚,雌霓,绛纱,茹藘。
  const customPrimaryColor = [
    '#fff799', '#ffee6f', '#ecd452', '#b6a014 ', '#f9d3e3', '#ffee6f', '#dd7694', '#a76283 ',
    '#ba5b49', '#ffee6f', '#9e2a22', '#7c191e ', '#ebeee8', '#ebeddf', '#9e2a22', '#c7c6b6 ',
    '#a6559d', '#8a1874', '#6c216d', '#422256', '#dcc7e1', '#bba1cb', '#a67eb7', '#7d5284 ',
    '#c3d94e', '#b7d332', '#9ebc19', '#84a729 ', '#e2a2ac', '#dd6b7b', '#c25160', '#b81a35 ',
    '#d5d1ae', '#bfc096', '#a9a886', '#92905d ', '#cb523e', '#b13b2e', '#95302e', '#822327',
    '#f5b087', '#f18f60', '#ef845d', '#ed6d46 ', '#e3adb9', '#cf929e', '#b27777', '#a35f65 ',

  ]
  // 定义自定义主题颜色中国传统24节气色谱：
  //窃蓝,监德,苍苍,群青,退红,樱花,丁香,木槿,
  // 凝脂,玉色,黄润,缣缃,卵色,葭菼,冰台,青古,
  // 醽醁,翠涛,青梅,翕赩,银朱,胭脂虫,朱樱,爵头,
  // 半见,女贞黄,绢纨,姜黄,月白,星郎,晴山,品月,
  // 雀梅,油绿,莓莓,螺青,濯绛,墨黪,驖骊,京元,
  // 并天,正青,扁青,䌦色,石英,银褐,烟红,紫诰,
  const customSecondaryColor = [
    '#88abda', '#6f94cd', '#5976ba', '#2e59a7 ', '#f0cfe3', '#e4b8d5', '#ce93bf', '#ba79b1 ',
    '#f5fe29', '#eae4d1', '#dfd6d8', '#d5c8a0 ', '#d5e3d4', '#cad7c5', '#becab7', '#b3bda9 ',
    '#a6bab1', '#819d8e', '#778a77', '#5f766a ', '#d12920', '#ab1d22', '#8f1d22', '#631216',
    '#fffbc7', '#f7eead', '#ece093', '#d6c560 ', '#d4e5ef', '#bcd4e7', '#a3bbdb', '#8aabcc ',
    '#788a6f', '#5d7259', '#4e6548', '#3f503b ', '#796860', '#585248', '#46433b', '#31322c ',
    '#a4c9cc', '#6ca8af', '#509296', '#2e59a7 ', '#c8b6bb', '#9c8d9b', '#9d858f', '#76555d ',

  ]
  const initChart = () => {

    const annualTarget = 112
    chart = echarts.init(proxy.$refs.chartRef, 'macarons')
    chart.setOption({
      //color: customColor,
      // tooltip: {
      //   trigger: 'axis',
      //   axisPointer: { // 坐标轴指示器，坐标轴触发有效
      //     type: 'shadow' // 默认为直线，可选为：'line' | 'shadow'
      //   }
      // },
      grid: {
        top: '15%',
        left: '10',
        right: '10',
        bottom: '20',
        containLabel: true
      },
      xAxis: [{
        data: salesDate,
        axisTick: {
          alignWithLabel: true
        }
      }],
      yAxis: [
        {
          name: "台数",
          nameTextStyle: {
            color: "#396A87",
            fontSize: 14
          },
          axisLabel: {
            formatter: '{value}'
          },
          axisTick: {
            show: true// 刻度
          },
          axisLine: {
            show: true
          }
        },
        {
          name: "金额",
          nameTextStyle: {
            color: "#396A87",
            fontSize: 14
          },
          axisLabel: {
            formatter: '{value}'
          },
          splitNumber: 5,
          axisLine: {
            show: true // 轴线
          },
          splitLine: {
            show: false // 网格线
          },
          axisTick: {
            show: true// 刻度
          }
        }
      ],

      //工具箱配置
      toolbox: {
        offsetY: 10,
        position: 'top',
        show: true,
        orient: 'horizontal',

        feature: {
          //  缩放
          // dataZoom: {
          //   yAxisIndex: 'none'
          // },
          // 数据视图
          dataView: {
            show: true,
            title: '数据视图',
            optionToContent: function (opt) {
              var axisData = opt.xAxis[0].data;
              var series = opt.series;
              var tdHeads = '<td  style="padding:0 10px;color:#FF9D6F">日期</td>';
              series.forEach(function (item) {
                tdHeads += '<td style="padding: 0 10px">' + item.name + '</td>';
              });
              var table = '<table border="1" style="user-select: text;color:#FF9D6F;margin-left:20px;border-collapse:collapse;font-size:14px;text-align:center"><tbody><tr>' + tdHeads + '</tr>';
              var tdBodys = '';
              for (var i = 0, l = axisData.length; i < l; i++) {
                for (var j = 0; j < series.length; j++) {
                  if (typeof (series[j].data[i]) == 'object') {
                    tdBodys += '<td>' + series[j].data[i].value + '</td>';
                  } else {
                    tdBodys += '<td>' + series[j].data[i] + '</td>';
                  }
                }
                table += '<tr><td style="padding: 0 10px">' + axisData[i] + '</td>' + tdBodys + '</tr>';
                tdBodys = '';
              }
              table += '</tbody></table>';
              return table;
            }
          },  //数据视图
          //magicType: { type: ['line', 'bar'] },   ///　　折线  直方图切换
          //restore: {}, // 重置
          //saveAsImage: {} // 导出图片
          //restore: { show: true },// 还原，复位原始图表
          saveAsImage: {
            show: true,
            title: 'IMG',
            name: 'DTA:' + '_月度销售统计',
          },// 保存为图片
        }
      },
      //图表标题
      title: {
        show: true,
        text: '月度销售统计',
        left: 'center', // title 组件离容器左侧的距离。      
        x: 'center'//标题水平方向位置
      },
      tooltip: {

        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
          type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
        formatter: '{b}<br />{a0}: {c0}<br />{a1}: {c1}万',//这是关键，在需要的地方加上就行了
      },
      legend: {
        left: 'left', // 图例组件离容器左侧的距离。
        x: 'center'//标题水平方向位置 
      },
      series: [{
        name: '台数',
        type: 'bar',
        //stack: 'salesQty',
        barWidth: '10%',
        data: salesQty,
        itemStyle: {

          normal: {
            barBorderRadius: [5, 5, 0, 0], // 加圆角 对应（顺时针左上，右上，右下，左下）
            // 这里的color指的是每个颜色的回调函数
            color: function (params) {
              console.log("Color parameters", params); //这里我们有七个柱状图，七份数据，所以会打印7次。
              // params.dataIndex指的是每个柱状图的索引下标 分别为0 1 2 3 4 5 6 7 8 9
              //var colorArr = ['#91cc75', '#fac858', '#ee6666', '#73c0de', '#3ba272', '#fc8452', '#9a60b4', '#ea7ccc', '#5470c6',]; //colorArr.length 为3，通过取模的方式就可以循环使用颜色了
              return customPrimaryColor[params.dataIndex % customPrimaryColor.length];


            },
            // 线性渐变，前四个参数分别是 x0, y0, x2, y2, 范围从 0 - 1，相当于在图形包围盒中的百分比，如果 globalCoord 为 `true`，则该四个值是绝对的像素位置

            label: {
              show: true, //开启显示
              //position: 'top', //在上方显示
              textStyle: { //数值样式
                color: 'white',
                // fontSize: 16
              }
            }
          }
        },
        animationDuration
      }, {
        name: '金额',
        type: 'line',
        //stack: 'salesAmount',
        barWidth: '10%',
        data: salesAmount,
        yAxisIndex: 1,
        symbol: 'circle',
        symbolSize: 10,
        label: {
          normal: {
            offsetY: 1,
            show: true,
            position: 'top',
            textStyle: {
              color: '#000',
            },
            //百分比格式
            formatter: '{c}万'//这是关键，在需要的地方加上就行了
          }

        },
        lineStyle: {
          // 这里的color指的是每个颜色的回调函数
          color: function (params) {
            //console.log("Color parameters", params); //这里我们有七个柱状图，七份数据，所以会打印7次。
            // params.dataIndex指的是每个柱状图的索引下标 分别为0 1 2 3 4 5 6 7 8 9
            //var colorArr = ['#5470c6', '#91cc75', '#fac858', '#ee6666', '#73c0de', '#3ba272', '#fc8452', '#9a60b4', '#ea7ccc']; //colorArr.length 为3，通过取模的方式就可以循环使用颜色了
            return customSecondaryColor[params.dataIndex % customSecondaryColor.length];
          },
        },
        areaStyle: {
          normal: {
            color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
              offset: 1,
              color: 'rgba(219, 50, 51, 0.3)'
            }, {
              offset: 0.8,
              color: 'rgba(219, 50, 51, 0)'
            }], false),
            shadowColor: 'rgba(0, 0, 0, 0.1)',
            shadowBlur: 10
          }
        },
        itemStyle: {

          normal: {
            // barBorderRadius: [5, 5, 0, 0], // 加圆角 对应（顺时针左上，右上，右下，左下）
            // // 这里的color指的是每个颜色的回调函数
            // color: function (params) {
            //   console.log("Color parameters", params); //这里我们有七个柱状图，七份数据，所以会打印7次。
            //   // params.dataIndex指的是每个柱状图的索引下标 分别为0 1 2 3 4 5 6 7 8 9
            //   var colorArr = ['#91cc75', '#fac858', '#ee6666', '#73c0de', '#3ba272', '#fc8452', '#9a60b4', '#ea7ccc', '#5470c6',]; //colorArr.length 为3，通过取模的方式就可以循环使用颜色了
            //   return colorArr[params.dataIndex % colorArr.length];

            // },
            ///  通过params.value拿到对应的data里面的数据
            color: function (params) {
              if (params.value < annualTarget) {
                return "#ed1941";
              } else if (params.value >= annualTarget) {
                return "#1d953f";
              }
              return "#225a1f";
            },
            //color: 'rgb(219,50,51)',
            //borderColor: randomRGBA,
            borderColor: 'rgba(72,209,204,0.2)',
            borderWidth: 12
          }
        },

        // markLine: {
        //   label: {
        //     fontSize: 9,
        //     show: true,
        //     formatter: '{b}:{c}%',
        //     position: 'insideEndTop',

        //   },
        //   lineStyle: {
        //     type: 'dashed',//dashed虚线，solid实绩
        //     width: 2
        //   },
        //   data: [{
        //     name: 'FY2024目标',
        //     yAxis: annualTarget,
        //     itemStyle: {
        //       normal: {
        //         color: '#ff6d9d'
        //       }
        //     }
        //   }]
        // },

        animationDuration
      },]
    })

  };

  onMounted(() => {
    getBarList()
    initChart()
  })
  window.onresize = function () {
    chart.resize()
  }
</script>