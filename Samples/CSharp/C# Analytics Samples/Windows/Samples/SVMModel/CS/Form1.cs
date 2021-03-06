﻿using Syncfusion.PMML;
using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVMModel
{
    public partial class Form1 : MetroForm
    {
        private Syncfusion.PMML.Table outputTable = null;
        DataTable inputDataTable = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var mergeTable = MergeTable(inputDataTable, outputTable);
            this.gridGroupingControl1.DataSource = mergeTable;
            this.gridGroupingControl1.Table.DefaultCaptionRowHeight = 25;
            this.gridGroupingControl1.Table.DefaultColumnHeaderRowHeight = 30;
            this.gridGroupingControl1.Table.DefaultRecordRowHeight = 22;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;

            for (int i = 0; i < mergeTable.Columns.Count; i++)
            {
                if (i >= inputDataTable.Columns.Count - 1)
                {
                    this.gridGroupingControl1.TableDescriptor.Columns[i].Appearance.AnyRecordFieldCell.BackColor = Color.FromArgb(214, 211, 209);
                }
            }
        }

        private DataTable MergeTable(DataTable inputDataTable, Syncfusion.PMML.Table outputTable)
        {
            var lenth = 0;
            string pmmlPath = "../../Model/sample_libsvm_data.pmml";
            string inputPath = "../../Model/sample_libsvm_data.txt";
            string[] lines = System.IO.File.ReadAllLines(inputPath);
            outputTable = PredictResult(lines, pmmlPath);
            string[] inputValues = lines[0].Split(' ');
            lenth = inputValues.Length;
            for (int i = 0; i < 692; i++)
            {
                if (i == 0)
                {
                    inputDataTable.Columns.Add("target");
                }
                inputDataTable.Columns.Add("field_" + i);
            }
            foreach (var item in lines)
            {
                inputValues = item.Split(' ');
                inputDataTable.Rows.Add(inputValues);

            }
            var columnEnumarator = outputTable.ColumnNames.GetEnumerator();

            while (columnEnumarator.MoveNext())
            {
                var column = new DataColumn() { ColumnName = columnEnumarator.Current.ToString() };
                inputDataTable.Columns.Add(column);
            }

            for (int i = 0; i < inputDataTable.Rows.Count; i++)
            {
                for (int j = 0; j < outputTable.ColumnNames.Length; j++)
                {
                    inputDataTable.Rows[i].SetField(outputTable.ColumnNames[j], outputTable[i, j]);
                }
            }

            return inputDataTable;
        }


        #region PredictResult

        /// <summary>
        /// Predicts the results for given PMML and CSV file and serialize the results in a CSV file
        /// </summary>
        public Syncfusion.PMML.Table PredictResult(string[] input, string pmmlPath)
        {
            //Get PMML Evaluator instance
            PMMLEvaluator evaluator = new PMMLEvaluatorFactory().
              GetPMMLEvaluatorInstance(pmmlPath);

            string[] predictedCategories = null;
            int i = 0;
            Dictionary<int, int> inputCollection = new Dictionary<int, int>();
            Dictionary<int, int> sortedCollection = new Dictionary<int, int>();
            foreach (string s in input)
            {
                string[] inputRow = s.Split(' ');

                for (int j = 1; j < inputRow.Length; j++)
                {
                    inputCollection.Add(Convert.ToInt16(inputRow[j].Split(':')[0]), Convert.ToInt16(inputRow[j].Split(':')[1]));
                }

                for (int k = 0; k < 692; k++)
                {
                    if (inputCollection.ContainsKey(k))
                        sortedCollection.Add(k, inputCollection[k]);
                    else
                        sortedCollection.Add(k, 0);
                }
                var record = new
                {
                    field_0 = sortedCollection.Values.ElementAt(0),
                    field_1 = sortedCollection.Values.ElementAt(1),
                    field_2 = sortedCollection.Values.ElementAt(2),
                    field_3 = sortedCollection.Values.ElementAt(3),
                    field_4 = sortedCollection.Values.ElementAt(4),
                    field_5 = sortedCollection.Values.ElementAt(5),
                    field_6 = sortedCollection.Values.ElementAt(6),
                    field_7 = sortedCollection.Values.ElementAt(7),
                    field_8 = sortedCollection.Values.ElementAt(8),
                    field_9 = sortedCollection.Values.ElementAt(9),
                    field_10 = sortedCollection.Values.ElementAt(10),
                    field_11 = sortedCollection.Values.ElementAt(11),
                    field_12 = sortedCollection.Values.ElementAt(12),
                    field_13 = sortedCollection.Values.ElementAt(13),
                    field_14 = sortedCollection.Values.ElementAt(14),
                    field_15 = sortedCollection.Values.ElementAt(15),
                    field_16 = sortedCollection.Values.ElementAt(16),
                    field_17 = sortedCollection.Values.ElementAt(17),
                    field_18 = sortedCollection.Values.ElementAt(18),
                    field_19 = sortedCollection.Values.ElementAt(19),
                    field_20 = sortedCollection.Values.ElementAt(20),
                    field_21 = sortedCollection.Values.ElementAt(21),
                    field_22 = sortedCollection.Values.ElementAt(22),
                    field_23 = sortedCollection.Values.ElementAt(23),
                    field_24 = sortedCollection.Values.ElementAt(24),
                    field_25 = sortedCollection.Values.ElementAt(25),
                    field_26 = sortedCollection.Values.ElementAt(26),
                    field_27 = sortedCollection.Values.ElementAt(27),
                    field_28 = sortedCollection.Values.ElementAt(28),
                    field_29 = sortedCollection.Values.ElementAt(29),
                    field_30 = sortedCollection.Values.ElementAt(30),
                    field_31 = sortedCollection.Values.ElementAt(31),
                    field_32 = sortedCollection.Values.ElementAt(32),
                    field_33 = sortedCollection.Values.ElementAt(33),
                    field_34 = sortedCollection.Values.ElementAt(34),
                    field_35 = sortedCollection.Values.ElementAt(35),
                    field_36 = sortedCollection.Values.ElementAt(36),
                    field_37 = sortedCollection.Values.ElementAt(37),
                    field_38 = sortedCollection.Values.ElementAt(38),
                    field_39 = sortedCollection.Values.ElementAt(39),
                    field_40 = sortedCollection.Values.ElementAt(40),
                    field_41 = sortedCollection.Values.ElementAt(41),
                    field_42 = sortedCollection.Values.ElementAt(42),
                    field_43 = sortedCollection.Values.ElementAt(43),
                    field_44 = sortedCollection.Values.ElementAt(44),
                    field_45 = sortedCollection.Values.ElementAt(45),
                    field_46 = sortedCollection.Values.ElementAt(46),
                    field_47 = sortedCollection.Values.ElementAt(47),
                    field_48 = sortedCollection.Values.ElementAt(48),
                    field_49 = sortedCollection.Values.ElementAt(49),
                    field_50 = sortedCollection.Values.ElementAt(50),
                    field_51 = sortedCollection.Values.ElementAt(51),
                    field_52 = sortedCollection.Values.ElementAt(52),
                    field_53 = sortedCollection.Values.ElementAt(53),
                    field_54 = sortedCollection.Values.ElementAt(54),
                    field_55 = sortedCollection.Values.ElementAt(55),
                    field_56 = sortedCollection.Values.ElementAt(56),
                    field_57 = sortedCollection.Values.ElementAt(57),
                    field_58 = sortedCollection.Values.ElementAt(58),
                    field_59 = sortedCollection.Values.ElementAt(59),
                    field_60 = sortedCollection.Values.ElementAt(60),
                    field_61 = sortedCollection.Values.ElementAt(61),
                    field_62 = sortedCollection.Values.ElementAt(62),
                    field_63 = sortedCollection.Values.ElementAt(63),
                    field_64 = sortedCollection.Values.ElementAt(64),
                    field_65 = sortedCollection.Values.ElementAt(65),
                    field_66 = sortedCollection.Values.ElementAt(66),
                    field_67 = sortedCollection.Values.ElementAt(67),
                    field_68 = sortedCollection.Values.ElementAt(68),
                    field_69 = sortedCollection.Values.ElementAt(69),
                    field_70 = sortedCollection.Values.ElementAt(70),
                    field_71 = sortedCollection.Values.ElementAt(71),
                    field_72 = sortedCollection.Values.ElementAt(72),
                    field_73 = sortedCollection.Values.ElementAt(73),
                    field_74 = sortedCollection.Values.ElementAt(74),
                    field_75 = sortedCollection.Values.ElementAt(75),
                    field_76 = sortedCollection.Values.ElementAt(76),
                    field_77 = sortedCollection.Values.ElementAt(77),
                    field_78 = sortedCollection.Values.ElementAt(78),
                    field_79 = sortedCollection.Values.ElementAt(79),
                    field_80 = sortedCollection.Values.ElementAt(80),
                    field_81 = sortedCollection.Values.ElementAt(81),
                    field_82 = sortedCollection.Values.ElementAt(82),
                    field_83 = sortedCollection.Values.ElementAt(83),
                    field_84 = sortedCollection.Values.ElementAt(84),
                    field_85 = sortedCollection.Values.ElementAt(85),
                    field_86 = sortedCollection.Values.ElementAt(86),
                    field_87 = sortedCollection.Values.ElementAt(87),
                    field_88 = sortedCollection.Values.ElementAt(88),
                    field_89 = sortedCollection.Values.ElementAt(89),
                    field_90 = sortedCollection.Values.ElementAt(90),
                    field_91 = sortedCollection.Values.ElementAt(91),
                    field_92 = sortedCollection.Values.ElementAt(92),
                    field_93 = sortedCollection.Values.ElementAt(93),
                    field_94 = sortedCollection.Values.ElementAt(94),
                    field_95 = sortedCollection.Values.ElementAt(95),
                    field_96 = sortedCollection.Values.ElementAt(96),
                    field_97 = sortedCollection.Values.ElementAt(97),
                    field_98 = sortedCollection.Values.ElementAt(98),
                    field_99 = sortedCollection.Values.ElementAt(99),
                    field_100 = sortedCollection.Values.ElementAt(100),
                    field_101 = sortedCollection.Values.ElementAt(101),
                    field_102 = sortedCollection.Values.ElementAt(102),
                    field_103 = sortedCollection.Values.ElementAt(103),
                    field_104 = sortedCollection.Values.ElementAt(104),
                    field_105 = sortedCollection.Values.ElementAt(105),
                    field_106 = sortedCollection.Values.ElementAt(106),
                    field_107 = sortedCollection.Values.ElementAt(107),
                    field_108 = sortedCollection.Values.ElementAt(108),
                    field_109 = sortedCollection.Values.ElementAt(109),
                    field_110 = sortedCollection.Values.ElementAt(110),
                    field_111 = sortedCollection.Values.ElementAt(111),
                    field_112 = sortedCollection.Values.ElementAt(112),
                    field_113 = sortedCollection.Values.ElementAt(113),
                    field_114 = sortedCollection.Values.ElementAt(114),
                    field_115 = sortedCollection.Values.ElementAt(115),
                    field_116 = sortedCollection.Values.ElementAt(116),
                    field_117 = sortedCollection.Values.ElementAt(117),
                    field_118 = sortedCollection.Values.ElementAt(118),
                    field_119 = sortedCollection.Values.ElementAt(119),
                    field_120 = sortedCollection.Values.ElementAt(120),
                    field_121 = sortedCollection.Values.ElementAt(121),
                    field_122 = sortedCollection.Values.ElementAt(122),
                    field_123 = sortedCollection.Values.ElementAt(123),
                    field_124 = sortedCollection.Values.ElementAt(124),
                    field_125 = sortedCollection.Values.ElementAt(125),
                    field_126 = sortedCollection.Values.ElementAt(126),
                    field_127 = sortedCollection.Values.ElementAt(127),
                    field_128 = sortedCollection.Values.ElementAt(128),
                    field_129 = sortedCollection.Values.ElementAt(129),
                    field_130 = sortedCollection.Values.ElementAt(130),
                    field_131 = sortedCollection.Values.ElementAt(131),
                    field_132 = sortedCollection.Values.ElementAt(132),
                    field_133 = sortedCollection.Values.ElementAt(133),
                    field_134 = sortedCollection.Values.ElementAt(134),
                    field_135 = sortedCollection.Values.ElementAt(135),
                    field_136 = sortedCollection.Values.ElementAt(136),
                    field_137 = sortedCollection.Values.ElementAt(137),
                    field_138 = sortedCollection.Values.ElementAt(138),
                    field_139 = sortedCollection.Values.ElementAt(139),
                    field_140 = sortedCollection.Values.ElementAt(140),
                    field_141 = sortedCollection.Values.ElementAt(141),
                    field_142 = sortedCollection.Values.ElementAt(142),
                    field_143 = sortedCollection.Values.ElementAt(143),
                    field_144 = sortedCollection.Values.ElementAt(144),
                    field_145 = sortedCollection.Values.ElementAt(145),
                    field_146 = sortedCollection.Values.ElementAt(146),
                    field_147 = sortedCollection.Values.ElementAt(147),
                    field_148 = sortedCollection.Values.ElementAt(148),
                    field_149 = sortedCollection.Values.ElementAt(149),
                    field_150 = sortedCollection.Values.ElementAt(150),
                    field_151 = sortedCollection.Values.ElementAt(151),
                    field_152 = sortedCollection.Values.ElementAt(152),
                    field_153 = sortedCollection.Values.ElementAt(153),
                    field_154 = sortedCollection.Values.ElementAt(154),
                    field_155 = sortedCollection.Values.ElementAt(155),
                    field_156 = sortedCollection.Values.ElementAt(156),
                    field_157 = sortedCollection.Values.ElementAt(157),
                    field_158 = sortedCollection.Values.ElementAt(158),
                    field_159 = sortedCollection.Values.ElementAt(159),
                    field_160 = sortedCollection.Values.ElementAt(160),
                    field_161 = sortedCollection.Values.ElementAt(161),
                    field_162 = sortedCollection.Values.ElementAt(162),
                    field_163 = sortedCollection.Values.ElementAt(163),
                    field_164 = sortedCollection.Values.ElementAt(164),
                    field_165 = sortedCollection.Values.ElementAt(165),
                    field_166 = sortedCollection.Values.ElementAt(166),
                    field_167 = sortedCollection.Values.ElementAt(167),
                    field_168 = sortedCollection.Values.ElementAt(168),
                    field_169 = sortedCollection.Values.ElementAt(169),
                    field_170 = sortedCollection.Values.ElementAt(170),
                    field_171 = sortedCollection.Values.ElementAt(171),
                    field_172 = sortedCollection.Values.ElementAt(172),
                    field_173 = sortedCollection.Values.ElementAt(173),
                    field_174 = sortedCollection.Values.ElementAt(174),
                    field_175 = sortedCollection.Values.ElementAt(175),
                    field_176 = sortedCollection.Values.ElementAt(176),
                    field_177 = sortedCollection.Values.ElementAt(177),
                    field_178 = sortedCollection.Values.ElementAt(178),
                    field_179 = sortedCollection.Values.ElementAt(179),
                    field_180 = sortedCollection.Values.ElementAt(180),
                    field_181 = sortedCollection.Values.ElementAt(181),
                    field_182 = sortedCollection.Values.ElementAt(182),
                    field_183 = sortedCollection.Values.ElementAt(183),
                    field_184 = sortedCollection.Values.ElementAt(184),
                    field_185 = sortedCollection.Values.ElementAt(185),
                    field_186 = sortedCollection.Values.ElementAt(186),
                    field_187 = sortedCollection.Values.ElementAt(187),
                    field_188 = sortedCollection.Values.ElementAt(188),
                    field_189 = sortedCollection.Values.ElementAt(189),
                    field_190 = sortedCollection.Values.ElementAt(190),
                    field_191 = sortedCollection.Values.ElementAt(191),
                    field_192 = sortedCollection.Values.ElementAt(192),
                    field_193 = sortedCollection.Values.ElementAt(193),
                    field_194 = sortedCollection.Values.ElementAt(194),
                    field_195 = sortedCollection.Values.ElementAt(195),
                    field_196 = sortedCollection.Values.ElementAt(196),
                    field_197 = sortedCollection.Values.ElementAt(197),
                    field_198 = sortedCollection.Values.ElementAt(198),
                    field_199 = sortedCollection.Values.ElementAt(199),
                    field_200 = sortedCollection.Values.ElementAt(200),
                    field_201 = sortedCollection.Values.ElementAt(201),
                    field_202 = sortedCollection.Values.ElementAt(202),
                    field_203 = sortedCollection.Values.ElementAt(203),
                    field_204 = sortedCollection.Values.ElementAt(204),
                    field_205 = sortedCollection.Values.ElementAt(205),
                    field_206 = sortedCollection.Values.ElementAt(206),
                    field_207 = sortedCollection.Values.ElementAt(207),
                    field_208 = sortedCollection.Values.ElementAt(208),
                    field_209 = sortedCollection.Values.ElementAt(209),
                    field_210 = sortedCollection.Values.ElementAt(210),
                    field_211 = sortedCollection.Values.ElementAt(211),
                    field_212 = sortedCollection.Values.ElementAt(212),
                    field_213 = sortedCollection.Values.ElementAt(213),
                    field_214 = sortedCollection.Values.ElementAt(214),
                    field_215 = sortedCollection.Values.ElementAt(215),
                    field_216 = sortedCollection.Values.ElementAt(216),
                    field_217 = sortedCollection.Values.ElementAt(217),
                    field_218 = sortedCollection.Values.ElementAt(218),
                    field_219 = sortedCollection.Values.ElementAt(219),
                    field_220 = sortedCollection.Values.ElementAt(220),
                    field_221 = sortedCollection.Values.ElementAt(221),
                    field_222 = sortedCollection.Values.ElementAt(222),
                    field_223 = sortedCollection.Values.ElementAt(223),
                    field_224 = sortedCollection.Values.ElementAt(224),
                    field_225 = sortedCollection.Values.ElementAt(225),
                    field_226 = sortedCollection.Values.ElementAt(226),
                    field_227 = sortedCollection.Values.ElementAt(227),
                    field_228 = sortedCollection.Values.ElementAt(228),
                    field_229 = sortedCollection.Values.ElementAt(229),
                    field_230 = sortedCollection.Values.ElementAt(230),
                    field_231 = sortedCollection.Values.ElementAt(231),
                    field_232 = sortedCollection.Values.ElementAt(232),
                    field_233 = sortedCollection.Values.ElementAt(233),
                    field_234 = sortedCollection.Values.ElementAt(234),
                    field_235 = sortedCollection.Values.ElementAt(235),
                    field_236 = sortedCollection.Values.ElementAt(236),
                    field_237 = sortedCollection.Values.ElementAt(237),
                    field_238 = sortedCollection.Values.ElementAt(238),
                    field_239 = sortedCollection.Values.ElementAt(239),
                    field_240 = sortedCollection.Values.ElementAt(240),
                    field_241 = sortedCollection.Values.ElementAt(241),
                    field_242 = sortedCollection.Values.ElementAt(242),
                    field_243 = sortedCollection.Values.ElementAt(243),
                    field_244 = sortedCollection.Values.ElementAt(244),
                    field_245 = sortedCollection.Values.ElementAt(245),
                    field_246 = sortedCollection.Values.ElementAt(246),
                    field_247 = sortedCollection.Values.ElementAt(247),
                    field_248 = sortedCollection.Values.ElementAt(248),
                    field_249 = sortedCollection.Values.ElementAt(249),
                    field_250 = sortedCollection.Values.ElementAt(250),
                    field_251 = sortedCollection.Values.ElementAt(251),
                    field_252 = sortedCollection.Values.ElementAt(252),
                    field_253 = sortedCollection.Values.ElementAt(253),
                    field_254 = sortedCollection.Values.ElementAt(254),
                    field_255 = sortedCollection.Values.ElementAt(255),
                    field_256 = sortedCollection.Values.ElementAt(256),
                    field_257 = sortedCollection.Values.ElementAt(257),
                    field_258 = sortedCollection.Values.ElementAt(258),
                    field_259 = sortedCollection.Values.ElementAt(259),
                    field_260 = sortedCollection.Values.ElementAt(260),
                    field_261 = sortedCollection.Values.ElementAt(261),
                    field_262 = sortedCollection.Values.ElementAt(262),
                    field_263 = sortedCollection.Values.ElementAt(263),
                    field_264 = sortedCollection.Values.ElementAt(264),
                    field_265 = sortedCollection.Values.ElementAt(265),
                    field_266 = sortedCollection.Values.ElementAt(266),
                    field_267 = sortedCollection.Values.ElementAt(267),
                    field_268 = sortedCollection.Values.ElementAt(268),
                    field_269 = sortedCollection.Values.ElementAt(269),
                    field_270 = sortedCollection.Values.ElementAt(270),
                    field_271 = sortedCollection.Values.ElementAt(271),
                    field_272 = sortedCollection.Values.ElementAt(272),
                    field_273 = sortedCollection.Values.ElementAt(273),
                    field_274 = sortedCollection.Values.ElementAt(274),
                    field_275 = sortedCollection.Values.ElementAt(275),
                    field_276 = sortedCollection.Values.ElementAt(276),
                    field_277 = sortedCollection.Values.ElementAt(277),
                    field_278 = sortedCollection.Values.ElementAt(278),
                    field_279 = sortedCollection.Values.ElementAt(279),
                    field_280 = sortedCollection.Values.ElementAt(280),
                    field_281 = sortedCollection.Values.ElementAt(281),
                    field_282 = sortedCollection.Values.ElementAt(282),
                    field_283 = sortedCollection.Values.ElementAt(283),
                    field_284 = sortedCollection.Values.ElementAt(284),
                    field_285 = sortedCollection.Values.ElementAt(285),
                    field_286 = sortedCollection.Values.ElementAt(286),
                    field_287 = sortedCollection.Values.ElementAt(287),
                    field_288 = sortedCollection.Values.ElementAt(288),
                    field_289 = sortedCollection.Values.ElementAt(289),
                    field_290 = sortedCollection.Values.ElementAt(290),
                    field_291 = sortedCollection.Values.ElementAt(291),
                    field_292 = sortedCollection.Values.ElementAt(292),
                    field_293 = sortedCollection.Values.ElementAt(293),
                    field_294 = sortedCollection.Values.ElementAt(294),
                    field_295 = sortedCollection.Values.ElementAt(295),
                    field_296 = sortedCollection.Values.ElementAt(296),
                    field_297 = sortedCollection.Values.ElementAt(297),
                    field_298 = sortedCollection.Values.ElementAt(298),
                    field_299 = sortedCollection.Values.ElementAt(299),
                    field_300 = sortedCollection.Values.ElementAt(300),
                    field_301 = sortedCollection.Values.ElementAt(301),
                    field_302 = sortedCollection.Values.ElementAt(302),
                    field_303 = sortedCollection.Values.ElementAt(303),
                    field_304 = sortedCollection.Values.ElementAt(304),
                    field_305 = sortedCollection.Values.ElementAt(305),
                    field_306 = sortedCollection.Values.ElementAt(306),
                    field_307 = sortedCollection.Values.ElementAt(307),
                    field_308 = sortedCollection.Values.ElementAt(308),
                    field_309 = sortedCollection.Values.ElementAt(309),
                    field_310 = sortedCollection.Values.ElementAt(310),
                    field_311 = sortedCollection.Values.ElementAt(311),
                    field_312 = sortedCollection.Values.ElementAt(312),
                    field_313 = sortedCollection.Values.ElementAt(313),
                    field_314 = sortedCollection.Values.ElementAt(314),
                    field_315 = sortedCollection.Values.ElementAt(315),
                    field_316 = sortedCollection.Values.ElementAt(316),
                    field_317 = sortedCollection.Values.ElementAt(317),
                    field_318 = sortedCollection.Values.ElementAt(318),
                    field_319 = sortedCollection.Values.ElementAt(319),
                    field_320 = sortedCollection.Values.ElementAt(320),
                    field_321 = sortedCollection.Values.ElementAt(321),
                    field_322 = sortedCollection.Values.ElementAt(322),
                    field_323 = sortedCollection.Values.ElementAt(323),
                    field_324 = sortedCollection.Values.ElementAt(324),
                    field_325 = sortedCollection.Values.ElementAt(325),
                    field_326 = sortedCollection.Values.ElementAt(326),
                    field_327 = sortedCollection.Values.ElementAt(327),
                    field_328 = sortedCollection.Values.ElementAt(328),
                    field_329 = sortedCollection.Values.ElementAt(329),
                    field_330 = sortedCollection.Values.ElementAt(330),
                    field_331 = sortedCollection.Values.ElementAt(331),
                    field_332 = sortedCollection.Values.ElementAt(332),
                    field_333 = sortedCollection.Values.ElementAt(333),
                    field_334 = sortedCollection.Values.ElementAt(334),
                    field_335 = sortedCollection.Values.ElementAt(335),
                    field_336 = sortedCollection.Values.ElementAt(336),
                    field_337 = sortedCollection.Values.ElementAt(337),
                    field_338 = sortedCollection.Values.ElementAt(338),
                    field_339 = sortedCollection.Values.ElementAt(339),
                    field_340 = sortedCollection.Values.ElementAt(340),
                    field_341 = sortedCollection.Values.ElementAt(341),
                    field_342 = sortedCollection.Values.ElementAt(342),
                    field_343 = sortedCollection.Values.ElementAt(343),
                    field_344 = sortedCollection.Values.ElementAt(344),
                    field_345 = sortedCollection.Values.ElementAt(345),
                    field_346 = sortedCollection.Values.ElementAt(346),
                    field_347 = sortedCollection.Values.ElementAt(347),
                    field_348 = sortedCollection.Values.ElementAt(348),
                    field_349 = sortedCollection.Values.ElementAt(349),
                    field_350 = sortedCollection.Values.ElementAt(350),
                    field_351 = sortedCollection.Values.ElementAt(351),
                    field_352 = sortedCollection.Values.ElementAt(352),
                    field_353 = sortedCollection.Values.ElementAt(353),
                    field_354 = sortedCollection.Values.ElementAt(354),
                    field_355 = sortedCollection.Values.ElementAt(355),
                    field_356 = sortedCollection.Values.ElementAt(356),
                    field_357 = sortedCollection.Values.ElementAt(357),
                    field_358 = sortedCollection.Values.ElementAt(358),
                    field_359 = sortedCollection.Values.ElementAt(359),
                    field_360 = sortedCollection.Values.ElementAt(360),
                    field_361 = sortedCollection.Values.ElementAt(361),
                    field_362 = sortedCollection.Values.ElementAt(362),
                    field_363 = sortedCollection.Values.ElementAt(363),
                    field_364 = sortedCollection.Values.ElementAt(364),
                    field_365 = sortedCollection.Values.ElementAt(365),
                    field_366 = sortedCollection.Values.ElementAt(366),
                    field_367 = sortedCollection.Values.ElementAt(367),
                    field_368 = sortedCollection.Values.ElementAt(368),
                    field_369 = sortedCollection.Values.ElementAt(369),
                    field_370 = sortedCollection.Values.ElementAt(370),
                    field_371 = sortedCollection.Values.ElementAt(371),
                    field_372 = sortedCollection.Values.ElementAt(372),
                    field_373 = sortedCollection.Values.ElementAt(373),
                    field_374 = sortedCollection.Values.ElementAt(374),
                    field_375 = sortedCollection.Values.ElementAt(375),
                    field_376 = sortedCollection.Values.ElementAt(376),
                    field_377 = sortedCollection.Values.ElementAt(377),
                    field_378 = sortedCollection.Values.ElementAt(378),
                    field_379 = sortedCollection.Values.ElementAt(379),
                    field_380 = sortedCollection.Values.ElementAt(380),
                    field_381 = sortedCollection.Values.ElementAt(381),
                    field_382 = sortedCollection.Values.ElementAt(382),
                    field_383 = sortedCollection.Values.ElementAt(383),
                    field_384 = sortedCollection.Values.ElementAt(384),
                    field_385 = sortedCollection.Values.ElementAt(385),
                    field_386 = sortedCollection.Values.ElementAt(386),
                    field_387 = sortedCollection.Values.ElementAt(387),
                    field_388 = sortedCollection.Values.ElementAt(388),
                    field_389 = sortedCollection.Values.ElementAt(389),
                    field_390 = sortedCollection.Values.ElementAt(390),
                    field_391 = sortedCollection.Values.ElementAt(391),
                    field_392 = sortedCollection.Values.ElementAt(392),
                    field_393 = sortedCollection.Values.ElementAt(393),
                    field_394 = sortedCollection.Values.ElementAt(394),
                    field_395 = sortedCollection.Values.ElementAt(395),
                    field_396 = sortedCollection.Values.ElementAt(396),
                    field_397 = sortedCollection.Values.ElementAt(397),
                    field_398 = sortedCollection.Values.ElementAt(398),
                    field_399 = sortedCollection.Values.ElementAt(399),
                    field_400 = sortedCollection.Values.ElementAt(400),
                    field_401 = sortedCollection.Values.ElementAt(401),
                    field_402 = sortedCollection.Values.ElementAt(402),
                    field_403 = sortedCollection.Values.ElementAt(403),
                    field_404 = sortedCollection.Values.ElementAt(404),
                    field_405 = sortedCollection.Values.ElementAt(405),
                    field_406 = sortedCollection.Values.ElementAt(406),
                    field_407 = sortedCollection.Values.ElementAt(407),
                    field_408 = sortedCollection.Values.ElementAt(408),
                    field_409 = sortedCollection.Values.ElementAt(409),
                    field_410 = sortedCollection.Values.ElementAt(410),
                    field_411 = sortedCollection.Values.ElementAt(411),
                    field_412 = sortedCollection.Values.ElementAt(412),
                    field_413 = sortedCollection.Values.ElementAt(413),
                    field_414 = sortedCollection.Values.ElementAt(414),
                    field_415 = sortedCollection.Values.ElementAt(415),
                    field_416 = sortedCollection.Values.ElementAt(416),
                    field_417 = sortedCollection.Values.ElementAt(417),
                    field_418 = sortedCollection.Values.ElementAt(418),
                    field_419 = sortedCollection.Values.ElementAt(419),
                    field_420 = sortedCollection.Values.ElementAt(420),
                    field_421 = sortedCollection.Values.ElementAt(421),
                    field_422 = sortedCollection.Values.ElementAt(422),
                    field_423 = sortedCollection.Values.ElementAt(423),
                    field_424 = sortedCollection.Values.ElementAt(424),
                    field_425 = sortedCollection.Values.ElementAt(425),
                    field_426 = sortedCollection.Values.ElementAt(426),
                    field_427 = sortedCollection.Values.ElementAt(427),
                    field_428 = sortedCollection.Values.ElementAt(428),
                    field_429 = sortedCollection.Values.ElementAt(429),
                    field_430 = sortedCollection.Values.ElementAt(430),
                    field_431 = sortedCollection.Values.ElementAt(431),
                    field_432 = sortedCollection.Values.ElementAt(432),
                    field_433 = sortedCollection.Values.ElementAt(433),
                    field_434 = sortedCollection.Values.ElementAt(434),
                    field_435 = sortedCollection.Values.ElementAt(435),
                    field_436 = sortedCollection.Values.ElementAt(436),
                    field_437 = sortedCollection.Values.ElementAt(437),
                    field_438 = sortedCollection.Values.ElementAt(438),
                    field_439 = sortedCollection.Values.ElementAt(439),
                    field_440 = sortedCollection.Values.ElementAt(440),
                    field_441 = sortedCollection.Values.ElementAt(441),
                    field_442 = sortedCollection.Values.ElementAt(442),
                    field_443 = sortedCollection.Values.ElementAt(443),
                    field_444 = sortedCollection.Values.ElementAt(444),
                    field_445 = sortedCollection.Values.ElementAt(445),
                    field_446 = sortedCollection.Values.ElementAt(446),
                    field_447 = sortedCollection.Values.ElementAt(447),
                    field_448 = sortedCollection.Values.ElementAt(448),
                    field_449 = sortedCollection.Values.ElementAt(449),
                    field_450 = sortedCollection.Values.ElementAt(450),
                    field_451 = sortedCollection.Values.ElementAt(451),
                    field_452 = sortedCollection.Values.ElementAt(452),
                    field_453 = sortedCollection.Values.ElementAt(453),
                    field_454 = sortedCollection.Values.ElementAt(454),
                    field_455 = sortedCollection.Values.ElementAt(455),
                    field_456 = sortedCollection.Values.ElementAt(456),
                    field_457 = sortedCollection.Values.ElementAt(457),
                    field_458 = sortedCollection.Values.ElementAt(458),
                    field_459 = sortedCollection.Values.ElementAt(459),
                    field_460 = sortedCollection.Values.ElementAt(460),
                    field_461 = sortedCollection.Values.ElementAt(461),
                    field_462 = sortedCollection.Values.ElementAt(462),
                    field_463 = sortedCollection.Values.ElementAt(463),
                    field_464 = sortedCollection.Values.ElementAt(464),
                    field_465 = sortedCollection.Values.ElementAt(465),
                    field_466 = sortedCollection.Values.ElementAt(466),
                    field_467 = sortedCollection.Values.ElementAt(467),
                    field_468 = sortedCollection.Values.ElementAt(468),
                    field_469 = sortedCollection.Values.ElementAt(469),
                    field_470 = sortedCollection.Values.ElementAt(470),
                    field_471 = sortedCollection.Values.ElementAt(471),
                    field_472 = sortedCollection.Values.ElementAt(472),
                    field_473 = sortedCollection.Values.ElementAt(473),
                    field_474 = sortedCollection.Values.ElementAt(474),
                    field_475 = sortedCollection.Values.ElementAt(475),
                    field_476 = sortedCollection.Values.ElementAt(476),
                    field_477 = sortedCollection.Values.ElementAt(477),
                    field_478 = sortedCollection.Values.ElementAt(478),
                    field_479 = sortedCollection.Values.ElementAt(479),
                    field_480 = sortedCollection.Values.ElementAt(480),
                    field_481 = sortedCollection.Values.ElementAt(481),
                    field_482 = sortedCollection.Values.ElementAt(482),
                    field_483 = sortedCollection.Values.ElementAt(483),
                    field_484 = sortedCollection.Values.ElementAt(484),
                    field_485 = sortedCollection.Values.ElementAt(485),
                    field_486 = sortedCollection.Values.ElementAt(486),
                    field_487 = sortedCollection.Values.ElementAt(487),
                    field_488 = sortedCollection.Values.ElementAt(488),
                    field_489 = sortedCollection.Values.ElementAt(489),
                    field_490 = sortedCollection.Values.ElementAt(490),
                    field_491 = sortedCollection.Values.ElementAt(491),
                    field_492 = sortedCollection.Values.ElementAt(492),
                    field_493 = sortedCollection.Values.ElementAt(493),
                    field_494 = sortedCollection.Values.ElementAt(494),
                    field_495 = sortedCollection.Values.ElementAt(495),
                    field_496 = sortedCollection.Values.ElementAt(496),
                    field_497 = sortedCollection.Values.ElementAt(497),
                    field_498 = sortedCollection.Values.ElementAt(498),
                    field_499 = sortedCollection.Values.ElementAt(499),
                    field_500 = sortedCollection.Values.ElementAt(500),
                    field_501 = sortedCollection.Values.ElementAt(501),
                    field_502 = sortedCollection.Values.ElementAt(502),
                    field_503 = sortedCollection.Values.ElementAt(503),
                    field_504 = sortedCollection.Values.ElementAt(504),
                    field_505 = sortedCollection.Values.ElementAt(505),
                    field_506 = sortedCollection.Values.ElementAt(506),
                    field_507 = sortedCollection.Values.ElementAt(507),
                    field_508 = sortedCollection.Values.ElementAt(508),
                    field_509 = sortedCollection.Values.ElementAt(509),
                    field_510 = sortedCollection.Values.ElementAt(510),
                    field_511 = sortedCollection.Values.ElementAt(511),
                    field_512 = sortedCollection.Values.ElementAt(512),
                    field_513 = sortedCollection.Values.ElementAt(513),
                    field_514 = sortedCollection.Values.ElementAt(514),
                    field_515 = sortedCollection.Values.ElementAt(515),
                    field_516 = sortedCollection.Values.ElementAt(516),
                    field_517 = sortedCollection.Values.ElementAt(517),
                    field_518 = sortedCollection.Values.ElementAt(518),
                    field_519 = sortedCollection.Values.ElementAt(519),
                    field_520 = sortedCollection.Values.ElementAt(520),
                    field_521 = sortedCollection.Values.ElementAt(521),
                    field_522 = sortedCollection.Values.ElementAt(522),
                    field_523 = sortedCollection.Values.ElementAt(523),
                    field_524 = sortedCollection.Values.ElementAt(524),
                    field_525 = sortedCollection.Values.ElementAt(525),
                    field_526 = sortedCollection.Values.ElementAt(526),
                    field_527 = sortedCollection.Values.ElementAt(527),
                    field_528 = sortedCollection.Values.ElementAt(528),
                    field_529 = sortedCollection.Values.ElementAt(529),
                    field_530 = sortedCollection.Values.ElementAt(530),
                    field_531 = sortedCollection.Values.ElementAt(531),
                    field_532 = sortedCollection.Values.ElementAt(532),
                    field_533 = sortedCollection.Values.ElementAt(533),
                    field_534 = sortedCollection.Values.ElementAt(534),
                    field_535 = sortedCollection.Values.ElementAt(535),
                    field_536 = sortedCollection.Values.ElementAt(536),
                    field_537 = sortedCollection.Values.ElementAt(537),
                    field_538 = sortedCollection.Values.ElementAt(538),
                    field_539 = sortedCollection.Values.ElementAt(539),
                    field_540 = sortedCollection.Values.ElementAt(540),
                    field_541 = sortedCollection.Values.ElementAt(541),
                    field_542 = sortedCollection.Values.ElementAt(542),
                    field_543 = sortedCollection.Values.ElementAt(543),
                    field_544 = sortedCollection.Values.ElementAt(544),
                    field_545 = sortedCollection.Values.ElementAt(545),
                    field_546 = sortedCollection.Values.ElementAt(546),
                    field_547 = sortedCollection.Values.ElementAt(547),
                    field_548 = sortedCollection.Values.ElementAt(548),
                    field_549 = sortedCollection.Values.ElementAt(549),
                    field_550 = sortedCollection.Values.ElementAt(550),
                    field_551 = sortedCollection.Values.ElementAt(551),
                    field_552 = sortedCollection.Values.ElementAt(552),
                    field_553 = sortedCollection.Values.ElementAt(553),
                    field_554 = sortedCollection.Values.ElementAt(554),
                    field_555 = sortedCollection.Values.ElementAt(555),
                    field_556 = sortedCollection.Values.ElementAt(556),
                    field_557 = sortedCollection.Values.ElementAt(557),
                    field_558 = sortedCollection.Values.ElementAt(558),
                    field_559 = sortedCollection.Values.ElementAt(559),
                    field_560 = sortedCollection.Values.ElementAt(560),
                    field_561 = sortedCollection.Values.ElementAt(561),
                    field_562 = sortedCollection.Values.ElementAt(562),
                    field_563 = sortedCollection.Values.ElementAt(563),
                    field_564 = sortedCollection.Values.ElementAt(564),
                    field_565 = sortedCollection.Values.ElementAt(565),
                    field_566 = sortedCollection.Values.ElementAt(566),
                    field_567 = sortedCollection.Values.ElementAt(567),
                    field_568 = sortedCollection.Values.ElementAt(568),
                    field_569 = sortedCollection.Values.ElementAt(569),
                    field_570 = sortedCollection.Values.ElementAt(570),
                    field_571 = sortedCollection.Values.ElementAt(571),
                    field_572 = sortedCollection.Values.ElementAt(572),
                    field_573 = sortedCollection.Values.ElementAt(573),
                    field_574 = sortedCollection.Values.ElementAt(574),
                    field_575 = sortedCollection.Values.ElementAt(575),
                    field_576 = sortedCollection.Values.ElementAt(576),
                    field_577 = sortedCollection.Values.ElementAt(577),
                    field_578 = sortedCollection.Values.ElementAt(578),
                    field_579 = sortedCollection.Values.ElementAt(579),
                    field_580 = sortedCollection.Values.ElementAt(580),
                    field_581 = sortedCollection.Values.ElementAt(581),
                    field_582 = sortedCollection.Values.ElementAt(582),
                    field_583 = sortedCollection.Values.ElementAt(583),
                    field_584 = sortedCollection.Values.ElementAt(584),
                    field_585 = sortedCollection.Values.ElementAt(585),
                    field_586 = sortedCollection.Values.ElementAt(586),
                    field_587 = sortedCollection.Values.ElementAt(587),
                    field_588 = sortedCollection.Values.ElementAt(588),
                    field_589 = sortedCollection.Values.ElementAt(589),
                    field_590 = sortedCollection.Values.ElementAt(590),
                    field_591 = sortedCollection.Values.ElementAt(591),
                    field_592 = sortedCollection.Values.ElementAt(592),
                    field_593 = sortedCollection.Values.ElementAt(593),
                    field_594 = sortedCollection.Values.ElementAt(594),
                    field_595 = sortedCollection.Values.ElementAt(595),
                    field_596 = sortedCollection.Values.ElementAt(596),
                    field_597 = sortedCollection.Values.ElementAt(597),
                    field_598 = sortedCollection.Values.ElementAt(598),
                    field_599 = sortedCollection.Values.ElementAt(599),
                    field_600 = sortedCollection.Values.ElementAt(600),
                    field_601 = sortedCollection.Values.ElementAt(601),
                    field_602 = sortedCollection.Values.ElementAt(602),
                    field_603 = sortedCollection.Values.ElementAt(603),
                    field_604 = sortedCollection.Values.ElementAt(604),
                    field_605 = sortedCollection.Values.ElementAt(605),
                    field_606 = sortedCollection.Values.ElementAt(606),
                    field_607 = sortedCollection.Values.ElementAt(607),
                    field_608 = sortedCollection.Values.ElementAt(608),
                    field_609 = sortedCollection.Values.ElementAt(609),
                    field_610 = sortedCollection.Values.ElementAt(610),
                    field_611 = sortedCollection.Values.ElementAt(611),
                    field_612 = sortedCollection.Values.ElementAt(612),
                    field_613 = sortedCollection.Values.ElementAt(613),
                    field_614 = sortedCollection.Values.ElementAt(614),
                    field_615 = sortedCollection.Values.ElementAt(615),
                    field_616 = sortedCollection.Values.ElementAt(616),
                    field_617 = sortedCollection.Values.ElementAt(617),
                    field_618 = sortedCollection.Values.ElementAt(618),
                    field_619 = sortedCollection.Values.ElementAt(619),
                    field_620 = sortedCollection.Values.ElementAt(620),
                    field_621 = sortedCollection.Values.ElementAt(621),
                    field_622 = sortedCollection.Values.ElementAt(622),
                    field_623 = sortedCollection.Values.ElementAt(623),
                    field_624 = sortedCollection.Values.ElementAt(624),
                    field_625 = sortedCollection.Values.ElementAt(625),
                    field_626 = sortedCollection.Values.ElementAt(626),
                    field_627 = sortedCollection.Values.ElementAt(627),
                    field_628 = sortedCollection.Values.ElementAt(628),
                    field_629 = sortedCollection.Values.ElementAt(629),
                    field_630 = sortedCollection.Values.ElementAt(630),
                    field_631 = sortedCollection.Values.ElementAt(631),
                    field_632 = sortedCollection.Values.ElementAt(632),
                    field_633 = sortedCollection.Values.ElementAt(633),
                    field_634 = sortedCollection.Values.ElementAt(634),
                    field_635 = sortedCollection.Values.ElementAt(635),
                    field_636 = sortedCollection.Values.ElementAt(636),
                    field_637 = sortedCollection.Values.ElementAt(637),
                    field_638 = sortedCollection.Values.ElementAt(638),
                    field_639 = sortedCollection.Values.ElementAt(639),
                    field_640 = sortedCollection.Values.ElementAt(640),
                    field_641 = sortedCollection.Values.ElementAt(641),
                    field_642 = sortedCollection.Values.ElementAt(642),
                    field_643 = sortedCollection.Values.ElementAt(643),
                    field_644 = sortedCollection.Values.ElementAt(644),
                    field_645 = sortedCollection.Values.ElementAt(645),
                    field_646 = sortedCollection.Values.ElementAt(646),
                    field_647 = sortedCollection.Values.ElementAt(647),
                    field_648 = sortedCollection.Values.ElementAt(648),
                    field_649 = sortedCollection.Values.ElementAt(649),
                    field_650 = sortedCollection.Values.ElementAt(650),
                    field_651 = sortedCollection.Values.ElementAt(651),
                    field_652 = sortedCollection.Values.ElementAt(652),
                    field_653 = sortedCollection.Values.ElementAt(653),
                    field_654 = sortedCollection.Values.ElementAt(654),
                    field_655 = sortedCollection.Values.ElementAt(655),
                    field_656 = sortedCollection.Values.ElementAt(656),
                    field_657 = sortedCollection.Values.ElementAt(657),
                    field_658 = sortedCollection.Values.ElementAt(658),
                    field_659 = sortedCollection.Values.ElementAt(659),
                    field_660 = sortedCollection.Values.ElementAt(660),
                    field_661 = sortedCollection.Values.ElementAt(661),
                    field_662 = sortedCollection.Values.ElementAt(662),
                    field_663 = sortedCollection.Values.ElementAt(663),
                    field_664 = sortedCollection.Values.ElementAt(664),
                    field_665 = sortedCollection.Values.ElementAt(665),
                    field_666 = sortedCollection.Values.ElementAt(666),
                    field_667 = sortedCollection.Values.ElementAt(667),
                    field_668 = sortedCollection.Values.ElementAt(668),
                    field_669 = sortedCollection.Values.ElementAt(669),
                    field_670 = sortedCollection.Values.ElementAt(670),
                    field_671 = sortedCollection.Values.ElementAt(671),
                    field_672 = sortedCollection.Values.ElementAt(672),
                    field_673 = sortedCollection.Values.ElementAt(673),
                    field_674 = sortedCollection.Values.ElementAt(674),
                    field_675 = sortedCollection.Values.ElementAt(675),
                    field_676 = sortedCollection.Values.ElementAt(676),
                    field_677 = sortedCollection.Values.ElementAt(677),
                    field_678 = sortedCollection.Values.ElementAt(678),
                    field_679 = sortedCollection.Values.ElementAt(679),
                    field_680 = sortedCollection.Values.ElementAt(680),
                    field_681 = sortedCollection.Values.ElementAt(681),
                    field_682 = sortedCollection.Values.ElementAt(682),
                    field_683 = sortedCollection.Values.ElementAt(683),
                    field_684 = sortedCollection.Values.ElementAt(684),
                    field_685 = sortedCollection.Values.ElementAt(685),
                    field_686 = sortedCollection.Values.ElementAt(686),
                    field_687 = sortedCollection.Values.ElementAt(687),
                    field_688 = sortedCollection.Values.ElementAt(688),
                    field_689 = sortedCollection.Values.ElementAt(689),
                    field_690 = sortedCollection.Values.ElementAt(690),
                    field_691 = sortedCollection.Values.ElementAt(691)
                };
                PredictedResult predictedResult = evaluator.GetResult(record, null);


                if (i == 0)
                {
                    //Get the predicted propability fields
                    predictedCategories = predictedResult.GetPredictedCategories();
                    //Initialize the output table
                    InitializeTable(input.Length, predictedCategories);

                }

                //Add predicted value
                outputTable[i, 0] = predictedResult.PredictedValue;
                i++;
                inputCollection = new Dictionary<int, int>();
                sortedCollection = new Dictionary<int, int>();
            }

            return outputTable;
        }

        #endregion PredictResult
        #region Initialize OutputTable

        /// <summary>
        /// Initialize the outputTable
        /// </summary>
        /// <param name="rowCount">rowCount of output table</param>
        /// <param name="predictedfield">predictedfield name</param>
        /// <param name="predictedCategories">probableFields</param>
        private void InitializeTable(int rowCount, string[] predictedCategories)
        {
            //Create instance to hold evaluated results
            outputTable = new Syncfusion.PMML.Table(rowCount, predictedCategories.Length + 1);

            //Add predicted column names
            outputTable.ColumnNames[0] = "Predicted";
        }

        #endregion Initialize OutputTable

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.label1.Height = 34;
                this.label1.Width = 1200;

            }
            else
            {
                this.label1.Height = 42;
                this.label1.Width = 895;

            }
        }
    }
}