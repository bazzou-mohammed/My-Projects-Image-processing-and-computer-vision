clear, clc, close all
%% TP Visionique et traitement d’images (Comptage de monnie)
%chargement des images
rep='C:\Users\Mohamed\OneDrive\Bureau\matlab scripts\TP_Monnaie\';
s=dir([rep, '*.JPG']);
for i=1:length(s)-1
    filename=[rep s(i).name];
    I=im2double(imread(filename));   
%     figure;imagesc(img), axis off; 
% séparation des cannales R V
% I = imread('M5.jpg');
end
R = I(:,:,1); % composante rouge
V = I(:,:,2); % composante verte
D = R-V;
for taille = 350 : 80 : 1150
DCT=dct2(D);   % transformation en cosinus 2D discret de l'image 
figure (2);imagesc(log(abs(DCT)));colormap jet; colorbar; 
title('spectre d amplitude de l image M5')
set(gca, 'FontName', 'Times New Roman', 'FontSize', 10);
[h,l]=size(D);
% création d'un mask pour la compression 
% taille = 350;   
% mask = zeros(h,l); 
% mask(1:taille,1:taille) = 1 ;
% figure ;imagesc(log(abs((DCT.*mask)))); colormap gray;colorbar;

% tau=100*(1-((taille/h).*(taille/l))); % taux de compression 
% reconstruction de l'image
% IDCT=idct2(DCT.*mask);
% figure;imagesc(IDCT); axis off,colormap gray
% title(['image M5 compresséé avec tau = ',num2str(tau),' % ']);

% figure; imagesc(D),axis off, colormap gray
% title ('Canal rouge - Canal vert')
% set(gca, 'FontName', 'Times New Roman', 'FontSize', 10);
bw = Noir_et_blanc(D);
% figure; imagesc(bw),axis off, colormap gray
% title ('Binarisation')
% set(gca, 'FontName', 'Times New Roman', 'FontSize', 10);
% remplissage des régions et des trous
fill = imfill(bw,'holes');
% figure; imagesc(fill),axis off, colormap gray
% title ('Remplissage des trous')
% set(gca, 'FontName', 'Times New Roman', 'FontSize', 10);
se = strel('disk',10);
eros = imerode(fill, se);
% figure; imagesc(eros),axis off, colormap gray
% title ('Erosion')
% set(gca, 'FontName', 'Times New Roman', 'FontSize', 10);
ouver = imopen(eros, se);
% figure; imagesc(ouver), axis off ,colormap gray
% Étiqueter et comptage des pièces 
[L, Ne] = bwlabel(ouver);
% Measure des propriétés de des objets sur l'image
prop = regionprops(L,'Area','Centroid');
%% initialisation du compteur
total=0;
%% le comptage de monnaie se bassera sur les surfaces des pièces
figure; imagesc(I),axis off,hold on
for n=1: size(prop,1)
    cent = prop(n).Centroid;
    X=cent(1);Y=cent(2); % coordonnées x et y de chaque monnaie
    if  (prop(n).Area >49000    &&  prop(n).Area < 54000)
        total=total+0.2;
        text(X-105,Y,'20 cent')
    elseif (prop(n).Area > 34861 && prop(n).Area < 40000)
        text(X-100,Y,'2 cent') 
        total=total+0.02; % en euro
    elseif (prop(n).Area > 68714 &&  prop(n).Area < 71000 &&  prop(n).Area~= 67068); 
        total=total+2;
        text(X-90,Y,'2 Euro') 
    end
end
end
hold on
title(['Total en Euro: ',num2str(total),' Euro'])
% end
%% Comptage de monnaie sur l'image M7
% IM_7 = imread('M7.jpg');
% figure; imagesc(IM_7),axis off, colormap gray
% title('M7')
% set(gca, 'FontName', 'Times New Roman', 'FontSize', 10);
% R_7 = IM_7(:,:,1); % composante rouge
% V_7 = IM_7(:,:,2); % composante verte
% D_7 = R_7 - V_7; %différence
% % % conversion en NG
% % NG_7 = im2double(rgb2gray(D_7));
% % conversion en NB
% bw_7 = Noir_et_blanc(D_7);
% % visualisation de l'image
% figure; imagesc(bw_7),axis off, colormap gray
% % remplissage des trous 
% M7_fill = imfill(bw_7,'holes');
% figure; imagesc(M7_fill), axis off,colormap gray
% % erosion 
% se1 = strel('disk',60);
% eros_M7 = imerode(M7_fill, se);
% figure; imagesc(eros_M7),axis off, colormap gray
% title('Erosion')
% set(gca, 'FontName', 'Times New Roman', 'FontSize', 10);
% % ouverture
% ouver_M7 = imopen(eros_M7, se1);
% figure; imagesc(ouver_M7),axis off, colormap gray
% title('Ouverture')
% set(gca, 'FontName', 'Times New Roman', 'FontSize', 10);
% [L_M7, Ne_M7] = bwlabel(ouver_M7);
% prop_M7 = regionprops(L_M7,'Area','Centroid');
% tot_M7 = 0;
% figure; imagesc(IM_7),axis off,hold on
% for n=1: size(prop_M7,1)
%     cent_M7 = prop_M7(n).Centroid;
%     X_M7=cent_M7(1);Y_M7=cent_M7(2); % coordonnées x et y de chaque monnaie
%     if  (prop_M7(n).Area >48800    &&  prop_M7(n).Area < 49730)
%         tot_M7=tot_M7+0.2;
%         text(X_M7-105,Y_M7,'20 cent')
%     elseif (prop_M7(n).Area > 35110 && prop_M7(n).Area < 36610)
%         text(X_M7-100,Y_M7,'2 cent') 
%         tot_M7=tot_M7+0.02; % en euro
%     elseif (prop_M7(n).Area > 68800 &&  prop_M7(n).Area < 69680); 
%         tot_M7=tot_M7+2;
%         text(X_M7-90,Y_M7,'2 Euro') 
%     end
% end
% hold on
% title(['Total en Euro: ',num2str(tot_M7),' Euro'])
%% 10 compressions sur l'image M5 du type transformée en cosinus discret
% IM5 = im2double(imread('M5.jpg'));
% NG = rgb2gray(IM5); % conversion en niveau de gris
% figure; imagesc(IM5),axis off, colormap gray
% % title('M5.jpg')
% % set(gca, 'FontName', 'Times New Roman', 'FontSize', 10);
% % calcul de la DCT de l'image M5 
% for taille = 350 : 80 : 1150
% DCT=dct2(NG);   % transformation en cosinus 2D discret de l'image 
% % figure (2);imagesc(log(abs(DCT)));colormap jet; colorbar; 
% % title('spectre d amplitude de l image M5')
% % set(gca, 'FontName', 'Times New Roman', 'FontSize', 10);
% [h,l]=size(NG);
% % création d'un mask pour la compression 
% % taille = 350;   
% mask = zeros(h,l); 
% mask(1:taille,1:taille) = 1 ;
% % figure ;imagesc(log(abs((DCT.*mask)))); colormap gray;colorbar;
% 
% tau=100*(1-((taille/h).*(taille/l))); % taux de compression 
% % reconstruction de l'image
% IDCT=idct2(DCT.*mask);
% figure;imagesc(IDCT); axis off,colormap gray
% title(['image M5 compresséé avec tau = ',num2str(tau),' % ']);
% end



